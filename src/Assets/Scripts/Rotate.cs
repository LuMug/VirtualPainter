using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>Rotate</c> serve a ruotare la tela.
/// </summary>
public class Rotate : MonoBehaviour
{
    /// <summary>
    /// Corrisponde all'oggetto tela.
    /// </summary>
    public GameObject tela;

    /// <summary>
    /// Corrisponde al grado di rotazione iniziale della tela.
    /// </summary>
    private Quaternion defaultRotation;

    /// <summary>
    /// Metodo richiamato prima del primo frame.
    /// </summary>
    void Start()
    {
        // Salvo la posizione iniziale della tela in un quaternione
        defaultRotation = tela.transform.rotation;
    }

    /// <summary>
    /// Metodo richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se viene pressata la freccia destra
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Ruota la tela verso destra
            RotateRight();
        }

        // Se viene premuta la freccia a sinistra
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // la tela ruota verso sinistra
            RotateLeft();
        }

        // Se viene premuta la barra spaziatrice
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // rimette la tela in posizione iniziale
            NormalizeRotation();
        }
    }

    /// <summary>
    /// Ruota la tela verso destra.
    /// </summary>
    public void RotateRight()
    {
        tela.transform.Rotate(new Vector3(0, 0.5f,0));
    }

    /// <summary>
    /// Ruota la tela verso sinistra.
    /// </summary>
    public void RotateLeft()
    {
        tela.transform.Rotate(new Vector3(0, -0.5f,0));
    }

    /// <summary>
    /// Resetta la tela in posizione originale.
    /// </summary>
    public void NormalizeRotation()
    {
        tela.transform.rotation = defaultRotation;    
    }
}
