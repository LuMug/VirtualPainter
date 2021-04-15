using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // tela
    public GameObject tela;

    // posizione iniziale
    private Vector3 oldPosition;


    // Start is called before the first frame update
    void Start()
    {
        // Salva la posizione iniziale della tela rispetto alla telecamera
        oldPosition = tela.transform.position;
    }

    // Update is called once per frame
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

    /**
     * Avvicina la tela alla telecamera donando un effetto di Zoom In.
     */
    public void ZoomIn()
    {
        // La tela si avvicina alla telecamera
         tela.transform.position += new Vector3(0,0,1);
        
    }

    /**
     * Allontana la tela dalla telecamera
     */
    public void ZoomOut()
    {
        tela.transform.position -= new Vector3(0,0,1);
    }

    /**
     * Rimette la tela in posizione originale
     */
    public void NormalizeZoom()
    {
        tela.transform.position = oldPosition;
    }
}
