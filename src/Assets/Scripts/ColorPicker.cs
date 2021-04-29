// author: Zeno Darani
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualPainter
{
    ///<summary>
    /// Classe utile per il funzionamento del componente ColorPicker. Il componente
    /// è composto da 4 slider per i 4 valori del colore(RGBA), 4 text per mostrare
    /// 4 valori degli slider, e un GameObject che rappresenterà il colore che si sta
    /// scegliendo.Questo GameObject al momento del caricamento dello script verrà
    /// clonato per creare una matrice di colori.Il GameObject necessita quindi di un
    /// materiale per una corretta rappresentazione del colore.
    /// </summary>
    public class ColorPicker : MonoBehaviour
    {
        ///<summary>
        /// Il numero di righe della matrice di colori della paletta.
        /// A dipendenza di questo numero verranno generate le righe
        /// clonando il GameObject della proprietà color.
        /// </summary>
        private const int ROWS_OF_SELECTABLE_COLORS = 4;

        ///<summary>
        /// Il numero di colonne della matrice di colori della paletta.
        /// A dipendenza di questo numero verranno generate le colonne
        /// clonando il GameObject della proprietà color.
        ///</summary>
        private const int COLS_OF_SELECTABLE_COLORS = 3;

        ///<summary>
        /// Rappresenta lo spazio tra i GameObject che rappresentano i colori
        /// della paletta.
        /// </summary>
        private const float COLORS_DISTANCE = 0.2f;

        ///<summary>
        /// Il colore di default che avrano tutti i pallini all'inizio.
        /// </summary>
        public Color DefaultColor = new Color(0, 0, 0);

        ///<summary>
        /// Di quanto il pallino che rappresenta il colore selezionato deve essere
        /// ingrandito per mostrare che è quello selezionato.
        ///</summary>
        public const float SELECTED_COLOR_SIZE_INCR = 1.5f;

        ///<summary>
        /// Il GameObject alla quale al materiale viene assegnato il colore che si sta selezionando.
        /// Questo GameObject verrà clonato ROWS_OF_SELECTABLE_COLORS * COLS_OF_SELECTABLE_COLORS volte
        /// così da poter avere una paletta con più colori.
        /// </summary>
        public GameObject Color;

        ///<summary>
        /// Lo slider per selezionare il valore rosso del colore selezionato. I valori dello
        /// slider devono essere compresi tra 0.0 e 1.0.
        /// </summary>
        public InteractionSlider SliderRed;

        ///<summary>
        /// Lo slider per selezionare il valore verde del colore selezionato. I valori dello
        /// slider devono essere compresi tra 0.0 e 1.0.
        /// </summary>
        public InteractionSlider SliderGreen;

        ///<summary>
        /// Lo slider per selezionare il valore blu del colore selezionato. I valori dello
        /// slider devono essere compresi tra 0.0 e 1.0.
        /// </summary>
        public InteractionSlider SliderBlue;

        ///<summary>
        /// Lo slider per selezionare il valore alpha del colore selezionato. I valori dello
        /// slider devono essere compresi tra 0.0 e 1.0.
        /// </summary>
        public InteractionSlider SliderAlpha;

        ///<summary>
        /// Il testo che mostra il valore rosso del colore selezionato. Questo valore è rappresentato
        /// da un numero compreso tra 0 e 255.
        /// </summary>
        public TextMesh RValue;

        ///<summary>
        /// Il testo che mostra il valore verde del colore selezionato. Questo valore è rappresentato
        /// da un numero compreso tra 0 e 255.
        /// </summary>
        public TextMesh GValue;

        ///<summary>
        /// Il testo che mostra il valore blu del colore selezionato. Questo valore è rappresentato
        /// da un numero compreso tra 0 e 255.
        /// </summary>
        public TextMesh BValue;

        ///<summary>
        /// Il testo che mostra il valore aplha del colore selezionato. Questo valore è rappresentato
        /// da un numero compreso tra 0 e 255.
        /// </summary>
        public TextMesh AValue;

        /// <summary>
        /// Il valore del colore selezionato.
        /// </summary>
        public Color SelectedColor 
        {
            get
            { 
                if(!activeColor == null)
                {
                    return activeColor.GetComponent<MeshRenderer>().material.color;
                }
                else
                {
                    return new Color(0, 0, 0, 255);
                }
                 
            }
        }

        /// <summary>
        /// Il GameObject che rappresenta il colore attualmente selezionato.
        /// </summary>
        private GameObject activeColor;

        /// <summary>
        /// I GameObcject che servono a rappresentare i colori della tavolozza.
        /// Questi colori sono creati clonando la proprietà GameObject color.
        /// </summary>
        private List<GameObject> Colori;

        void Start()
        {
            SliderRed.HorizontalSlideEvent = new Action<float>(OnChangedRed);
            SliderGreen.HorizontalSlideEvent = new Action<float>(OnChangedGreen);
            SliderBlue.HorizontalSlideEvent = new Action<float>(OnChangedBlue);
            SliderAlpha.HorizontalSlideEvent = new Action<float>(OnChangedAlpha);
            activeColor = Color;
            OnChangedRed(DefaultColor.r);
            OnChangedGreen(DefaultColor.g);
            OnChangedBlue(DefaultColor.b);
            OnChangedAlpha(DefaultColor.a);
            Colori = new List<GameObject>();
            Color.GetComponent<InteractionButton>().OnPress = new Action(OnColorSelected);
            Colori.Add(Color);
            for (int i = 0; i < ROWS_OF_SELECTABLE_COLORS; i++)
            {
                for (int j = 0; j < COLS_OF_SELECTABLE_COLORS; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        GameObject clone = Instantiate(Color);
                        clone.GetComponent<Transform>().SetParent(Color.GetComponent<Transform>().parent);
                        clone.GetComponent<Transform>().localPosition = Color.GetComponent<Transform>().localPosition + new Vector3(j * COLORS_DISTANCE / 2, -i * COLORS_DISTANCE, 0);
                        clone.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
                        clone.GetComponent<Transform>().localScale = Color.GetComponent<Transform>().localScale;
                        clone.GetComponent<InteractionButton>().OnPress = new Action(OnColorSelected);
                        Material cloneMaterial = Instantiate(Color.GetComponent<Renderer>().material);
                        clone.GetComponent<Renderer>().material = cloneMaterial;
                        Colori.Add(clone);
                    }
                }
            }
            Color.GetComponent<Transform>().localScale = new Vector3(
                activeColor.GetComponent<Transform>().localScale.x * SELECTED_COLOR_SIZE_INCR,
                activeColor.GetComponent<Transform>().localScale.y * SELECTED_COLOR_SIZE_INCR
            );
            OnColorSelected();
        }

        /// <summary>
        /// Metodo che imposta una determinata immagine come quella selezionata in
        /// modo da poterne modificare il valore del colore.
        /// </summary>
        private void OnColorSelected()
        {
            activeColor.GetComponent<Transform>().localScale = new Vector3(
                activeColor.GetComponent<Transform>().localScale.x / SELECTED_COLOR_SIZE_INCR,
                activeColor.GetComponent<Transform>().localScale.y / SELECTED_COLOR_SIZE_INCR
            );
            foreach (GameObject color in Colori)
            {
                if (color.GetComponent<InteractionButton>().isPressed)
                {
                    activeColor = color;
                }
            }
            activeColor.GetComponent<Transform>().localScale = new Vector3(
                activeColor.GetComponent<Transform>().localScale.x * SELECTED_COLOR_SIZE_INCR,
                activeColor.GetComponent<Transform>().localScale.y * SELECTED_COLOR_SIZE_INCR
            );
            SliderRed.GetComponent<InteractionSlider>().HorizontalSliderValue = activeColor.GetComponent<Renderer>().material.color.r;
            SliderGreen.GetComponent<InteractionSlider>().HorizontalSliderValue = activeColor.GetComponent<Renderer>().material.color.g;
            SliderBlue.GetComponent<InteractionSlider>().HorizontalSliderValue = activeColor.GetComponent<Renderer>().material.color.b;
            SliderAlpha.GetComponent<InteractionSlider>().HorizontalSliderValue = activeColor.GetComponent<Renderer>().material.color.a;
            Color32 c = activeColor.GetComponent<Renderer>().material.color;
            RValue.text = c.r.ToString();
            GValue.text = c.g.ToString();
            BValue.text = c.b.ToString();
            AValue.text = c.a.ToString();
        }


        /// <summary>
        /// Metodo che aggiorna il valore aplha del colore dell'immagine selezionata
        /// e aggiorna il testo che lo rappresenta.
        /// </summary>
        /// <param name="value">Il valore della componente Alpha da assegnare al colore.</param>
        private void OnChangedAlpha(float value)
        {
            activeColor.GetComponent<Renderer>().material.color = new Color(
                activeColor.GetComponent<Renderer>().material.color.r,
                activeColor.GetComponent<Renderer>().material.color.g,
                activeColor.GetComponent<Renderer>().material.color.b,
                value
            );
            Color32 c = activeColor.GetComponent<Renderer>().material.color;
            AValue.text = c.a.ToString();
        }

        /// <summary>
        /// Metodo che aggiorna il valore blu del colore dell'immagine selezionata
        /// e aggiorna il testo che lo rappresenta.
        /// </summary>
        /// <param name="value">Il valore della componente Blue da assegnare al colore.</param>
        private void OnChangedBlue(float value)
        {
            activeColor.GetComponent<Renderer>().material.color = new Color(
                activeColor.GetComponent<Renderer>().material.color.r,
                activeColor.GetComponent<Renderer>().material.color.g,
                value,
                activeColor.GetComponent<Renderer>().material.color.a
            );
            Color32 c = activeColor.GetComponent<Renderer>().material.color;
            BValue.text = c.b.ToString();
        }

        /// <summary>
        /// Metodo che aggiorna il valore verde del colore dell'immagine selezionata
        /// e aggiorna il testo che lo rappresenta.
        /// </summary>
        /// <param name="value">Il valore della componente Green da assegnare al colore.</param>
        private void OnChangedGreen(float value)
        {
            activeColor.GetComponent<Renderer>().material.color = new Color(
                activeColor.GetComponent<Renderer>().material.color.r,
                value,
                activeColor.GetComponent<Renderer>().material.color.b,
                activeColor.GetComponent<Renderer>().material.color.a
            );
            Color32 c = activeColor.GetComponent<Renderer>().material.color;
            GValue.text = c.g.ToString();
        }


        /// <summary>
        /// Metodo che aggiorna il valore rosso del colore dell'immagine selezionata
        /// e aggiorna il testo che lo rappresenta.
        /// </summary>
        /// <param name="value">Il valore della componente Red da assegnare al colore.</param>
        public void OnChangedRed(float value)
        {
            activeColor.GetComponent<Renderer>().material.color = new Color(
                value,
                activeColor.GetComponent<Renderer>().material.color.g,
                activeColor.GetComponent<Renderer>().material.color.b,
                activeColor.GetComponent<Renderer>().material.color.a
            );
            Color32 c = activeColor.GetComponent<Renderer>().material.color;
            RValue.text = c.r.ToString();
        }
    }
}
