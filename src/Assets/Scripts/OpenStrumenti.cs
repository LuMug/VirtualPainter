using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>OpenStrumenti</c> serve a mostrare il menù di selezione dello strumento attivo
/// e della grandezza della penna.
/// </summary>
public class OpenStrumenti : MonoBehaviour
{
    /// <summary>
    /// Bottone presente nel menù inventario per far apparire e sparire il menù degli strumenti.
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Indica se il bottone è stato premuto.
    /// </summary>
    private bool prevPress;

    /// <summary>
    /// Indica se il menù strumenti è visibile (attivo).
    /// </summary>
    private bool active = false;

    /// <summary>
    /// Corriponde al pannello di bottoni che funge da menù strumenti.
    /// </summary>
    public GameObject instrument;

    /// <summary>
    /// Corrisponde alla mano destra attiva.
    /// </summary>
    public GameObject rightHand;

    /// <summary>
    /// Metodo che viene richiamato una volta al primo frame.
    /// </summary>
    void Start()
    {
        // Nasconde il menù strumenti.
        instrument.SetActive(false);
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Metodo che viene richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se il bottone viene premuto e prima non era premuto
        if (button.isPressed && !prevPress)
        {
            // Se il menù strumenti è attivo lo setta come disattivato e viceversa.
            active = !active;
            // Mostra/nasconde il menù strumenti.
            instrument.SetActive(active);
            // Setta il bottone come premuto.
            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            // Setta il bottone come non premuto.
            prevPress = false;
        }
    }
}
