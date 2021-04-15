using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Tela
    public GameObject tela;

    // Posizione iniziale della tela
    private Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Salvo la posizione iniziale della tela in un quaternione
        defaultRotation = tela.transform.rotation;
    }

    // Update is called once per frame
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

    /**
     * Ruota la tela verso destra
     */
    public void RotateRight()
    {
        tela.transform.Rotate(new Vector3(0, 0.5f,0));
    }

    /**
     * Ruota la tela verso sinistra
     */
    public void RotateLeft()
    {
        tela.transform.Rotate(new Vector3(0, -0.5f,0));
    }

    /**
     * Resetta la posizione originale
     */
    public void NormalizeRotation()
    {
        tela.transform.rotation = defaultRotation;    
    }
}
