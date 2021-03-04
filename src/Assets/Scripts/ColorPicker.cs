using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 *  Classe utile per il funzionamento del componente ColorPicker. Il componente
 *  è composto da 4 slider per i 4 valori del colore (RGBA), 4 text per mostrare
 *  i 4 valori degli slider, e un ColorImage che rappresenterà il colore che si sta
 *  scegliendo. Questo color image al momento del caricamento dello script verrà
 *  clonato per un determinato numero di volte così da poter avere più colori 
 *  memorizzati nel ColorPicker.
 */
public class ColorPicker : MonoBehaviour
{
    /**
     * Il numero di volte che l'immagine rappresentante un colore verrà clonata
     * per creare altre immagini che conterrano altri colori.
     */
    public const int NUM_OF_SELECTABLE_COLORS = 12;
    /**
     * Il colore di default che avrano tutti i pallini all'inizio.
     */
    public Color DefaultColor = new Color(0,0,0);
    /**
     * Di quanto il pallino che rappresenta il colore selezionato deve essere 
     * ingrandito per mostrare che è quello selezionato.
     */
    public const int SELECTED_COLOR_SIZE_INCR = 10;
    /**
     * L'immagine alla quale viene assegnato il colore che si sta selezionando.
     * Quest'immagine verrà clonata ... volte per 
     */
    public Image ColorImage;
    /**
     * Lo slider per selezionare il valore rosso del colore selezionato. I valori dello
     * slider devono essere compresi tra 0.0 e 1.0.
     */
    public Slider SliderRed;
    /**
     * Lo slider per selezionare il valore verde del colore selezionato. I valori dello
     * slider devono essere compresi tra 0.0 e 1.0.
     */
    public Slider SliderGreen;
    /**
     * Lo slider per selezionare il valore blu del colore selezionato. I valori dello
     * slider devono essere compresi tra 0.0 e 1.0.
     */
    public Slider SliderBlue;
    /**
     * Lo slider per selezionare il valore alpha del colore selezionato. I valori dello
     * slider devono essere compresi tra 0.0 e 1.0.
     */
    public Slider SliderAlpha;
    /**
     * Il testo che mostra il valore rosso del colore selezionato. Questo valore è rappresentato
     * da un numero compreso tra 0 e 255.
     */
    public Text RValue;
    /**
     * Il testo che mostra il valore verde del colore selezionato. Questo valore è rappresentato
     * da un numero compreso tra 0 e 255.
     */
    public Text GValue;
    /**
     * Il testo che mostra il valore blu del colore selezionato. Questo valore è rappresentato
     * da un numero compreso tra 0 e 255.
     */
    public Text BValue;
    /**
     * Il testo che mostra il valore aplha del colore selezionato. Questo valore è rappresentato
     * da un numero compreso tra 0 e 255.
     */
    public Text AValue;
    /**
     * Il valore del colore selezionato.
     */
    public Color SelectedColor { get { return selectedColorImage.color; } }
    /**
     * L'imagine che rappresenta un colore attualmente selezionata.
     */
    private Image selectedColorImage;

    void Start()
    {
        SliderRed.onValueChanged.AddListener(OnChangedRed);
        SliderGreen.onValueChanged.AddListener(OnChangedGreen);
        SliderBlue.onValueChanged.AddListener(OnChangedBlue);
        SliderAlpha.onValueChanged.AddListener(OnChangedAlpha); 
        selectedColorImage = ColorImage;
        ColorImage.GetComponent<Button>().onClick.AddListener(() => OnColorSelected(ColorImage));
        for(int i = 0; i < NUM_OF_SELECTABLE_COLORS; i++)
        {
            Image clone = Instantiate(ColorImage);
            clone.color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, DefaultColor.a);
            clone.GetComponent<Transform>().SetParent(ColorImage.GetComponent<Transform>().parent);
            clone.GetComponent<Button>().onClick.AddListener(() => OnColorSelected(clone));
            clone.GetComponent<Transform>().localScale = new Vector3(1,1,1);
            clone.transform.localPosition = new Vector3(clone.transform.localPosition.x, clone.transform.localPosition.y,0);
        }
        selectedColorImage.GetComponent<RectTransform>().sizeDelta += new Vector2(SELECTED_COLOR_SIZE_INCR, SELECTED_COLOR_SIZE_INCR);
        OnChangedRed(DefaultColor.r);
        OnChangedGreen(DefaultColor.g);
        OnChangedBlue(DefaultColor.b);
        OnChangedAlpha(DefaultColor.a);
    }

    /**
     * Metodo che imposta una determinata immagine come quella selezionata in
     * modo da poterne modificare il valore del colore.
     */
    private void OnColorSelected(Image source)
    {
        source.GetComponent<RectTransform>().sizeDelta += new Vector2(SELECTED_COLOR_SIZE_INCR, SELECTED_COLOR_SIZE_INCR);
        selectedColorImage.GetComponent<RectTransform>().sizeDelta -= new Vector2(SELECTED_COLOR_SIZE_INCR, SELECTED_COLOR_SIZE_INCR);
        selectedColorImage = source;
        SliderRed.value = source.color.r;
        SliderGreen.value = source.color.g;
        SliderBlue.value = source.color.b;
        SliderAlpha.value = source.color.a;
    }

    /**
     * Metodo che aggiorna il valore aplha del colore dell'immagine selezionata
     * e aggiorna il testo che lo rappresenta.
     */
    private void OnChangedAlpha(float value)
    {
        selectedColorImage.color = new Color(selectedColorImage.color.r, selectedColorImage.color.g, selectedColorImage.color.b, value);
        Color32 c = selectedColorImage.color;
        AValue.text = c.a.ToString();
    }
    /**
     * Metodo che aggiorna il valore blu del colore dell'immagine selezionata
     * e aggiorna il testo che lo rappresenta.
     */
    private void OnChangedBlue(float value)
    {
        selectedColorImage.color = new Color(selectedColorImage.color.r, selectedColorImage.color.g, value, selectedColorImage.color.a);
        Color32 c = selectedColorImage.color;
        BValue.text = c.b.ToString();
    }
    /**
     * Metodo che aggiorna il valore verde del colore dell'immagine selezionata
     * e aggiorna il testo che lo rappresenta.
     */
    private void OnChangedGreen(float value)
    {
        selectedColorImage.color = new Color(selectedColorImage.color.r, value, selectedColorImage.color.b, selectedColorImage.color.a);
        Color32 c = selectedColorImage.color;
        GValue.text = c.g.ToString();
    }
    /**
     * Metodo che aggiorna il valore rosso del colore dell'immagine selezionata
     * e aggiorna il testo che lo rappresenta.
     */
    public void OnChangedRed(float value)
    {
        selectedColorImage.color = new Color(value, selectedColorImage.color.g, selectedColorImage.color.b, selectedColorImage.color.a);
        Color32 c = selectedColorImage.color;
        RValue.text = c.r.ToString();
    }
}
