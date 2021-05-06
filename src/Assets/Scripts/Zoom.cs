using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>Zoom</c> serve a fare zoom in e zoom out della tela.
/// </summary>
public class Zoom : MonoBehaviour
{
    /// <summary>
    /// Oggetto tela sulla quale disegnare.
    /// </summary>
    public GameObject tela;

    /// <summary>
    /// Corrisponde alla posizione originale della tela.
    /// </summary>
    private Vector3 oldPosition;


    /// <summary>
    /// Metodo che viene richiamato una volta prima del primo frame.
    /// </summary>
    void Start()
    {
        // Salva la posizione iniziale della tela rispetto alla telecamera
        oldPosition = tela.transform.position;
    }

    /// <summary>
    /// Metodo richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se viene premuto il bottone A
        if (Input.GetKey(KeyCode.A))
        {
            // Allontana la tela alla telecamera
            ZoomOut();
        }

        // Se viene premuto il bottone D
        if (Input.GetKey(KeyCode.D))
        {
            // Avvicina la tela alla telecamera
            ZoomIn();
        }

        // Se viene premuto il bottone S
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Riposiziona la tela alla posizione originale
            NormalizeZoom();
        }
    }

    /// <summary>
    /// Avvicina la tela alla telecamera donando un effetto di Zoom In.
    /// </summary>
    public void ZoomIn()
    {
        // La tela si avvicina alla telecamera
         tela.transform.position += new Vector3(0,0,1);
        
    }

    /// <summary>
    /// Allontana la tela dalla telecamera donando un effetto di Zoom Out.
    /// </summary>
    public void ZoomOut()
    {
        tela.transform.position -= new Vector3(0,0,1);
    }

    /// <summary>
    /// Reimposta la tela in posizione originale.
    /// </summary>
    public void NormalizeZoom()
    {
        tela.transform.position = oldPosition;
    }
}
