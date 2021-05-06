using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
// Author: Karim Galliciotti

/// <summary>
/// La classe <c>Undo</c> ha lo scopo di annullare l'ultima azione eseguita.
/// </summary>
public class Undo : MonoBehaviour
{
    /// <summary>
    /// Salva lo stato della mano (isPinched = true)
    /// </summary>
    bool last = false;

    /// <summary>
    /// Salva lo stato dei tasti ctrl+z (premuti = true)
    /// </summary>
    bool pressed = false;

    /// <summary>
    /// Contenitore delle mani.
    /// </summary>
    HandModel hand_model;

    /// <summary>
    /// La mano.
    /// </summary>
    Hand leap_hand;

    /// <summary>
    /// Lista delle texture sul quale è stata effettuata una modifica
    /// </summary>
    List<Texture2D> textures = new List<Texture2D>();

    /// <summary>
    /// La tela su cui disegnare.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Metodo eseguito all'avvio dello script.
    /// </summary>
    void Start()
    {
        hand_model = GetComponent<HandModel>();
        leap_hand = hand_model.GetLeapHand();
    }

    /// <summary>
    /// Metodo eseguito ad ogni frame.
    /// </summary>
    void Update()
    {
        try
        {
            if (leap_hand != null)
            {
                //Controlla che la mano sia pinchata e che non lo fosse prima e cambia lo stato della mano
                if (leap_hand.IsPinching() && !last)
                {
                    last = true;
                    Debug.Log("last true");
                }
                //Controlla che la mano non sia più pinchata e aggiunge la texture corrente alla lista
                else if (!leap_hand.IsPinching() && last)
                {
                    last = false;
                    Texture2D texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
                    if (textures.Count == 15)
                    {
                        textures.RemoveAt(0);
                    }
                    textures.Add(Instantiate(texture));
                    Debug.Log("aggiornato ultimo index con mani");
                }
            }
            // se la mano era pinchata e non sono più presenti manni sullo schermo aggiunge la texture corrente alla lista.
            else if (last)
            {
                last = false;
                Texture2D texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
                if (textures.Count == 15)
                {
                    textures.RemoveAt(0);
                }
                textures.Add(Instantiate(texture));
                Debug.Log("aggiornato ultimo index no mani");
            }

        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Mani non inserite");
        }
        // Se i tasti ctrl+z sono premuti e prima non lo erano la texture torna allo stato precedente e lo stato del ctrl+z viene settato a true
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Z) && !pressed)
        {
            Debug.Log(textures.Count);
            pressed = true;
            //Controlla che sia presente almeno una texture nella lista
            if (textures.Count > 1)
            {
                //Rimuove la texture attuale e applica quella dello stato precedente
                textures.RemoveAt(textures.Count - 1);
                var tex = textures.ElementAt(textures.Count - 1);
                telaDisegnabile.GetComponent<Renderer>().material.mainTexture = tex;
                tex.Apply();
            }
        }
        // Se uno dei due testi non è premuto lo stato del ctrl+z viene settato a false
        else if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetKey(KeyCode.Z))
        {
            pressed = false;
        }
    }
}
