using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{
    // tela
    public GameObject tela;

    // posizione iniziale
    private Vector3 oldPosition;

    // indica se la tela si può muovere oppure no
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        // Salva la posizione iniziale della tela rispetto alla telecamera
        oldPosition = tela.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            // Se viene premuto il bottone 8
            if (Input.GetKey(KeyCode.Keypad8))
            {
                // Sposta la tela in su
                MoveUp();
            }

            // Se viene premuto il bottone 4
            if (Input.GetKey(KeyCode.Keypad4))
            {
                // Sposta la tela a sinistra
                MoveLeft();
            }

            // Se viene premuto il bottone 6
            if (Input.GetKey(KeyCode.Keypad6))
            {
                // Sposta la tela a destra
                MoveRight();
            }

            // Se viene premuto il bottone 2
            if (Input.GetKey(KeyCode.Keypad2))
            {
                // Sposta la tela in giu
                MoveDown();
            }

            // Se viene premuto il bottone c
            if (Input.GetKey(KeyCode.C))
            {
                // Sposta la tela in giu
                ResetPoition();
            }
        }
    }

    /**
     * Fa in modo che la tela si muova.
     */
    public void SetCanMove()
    {
        canMove = true;
    }

    /**
     * Fa in modo che la tela non possa muoversi.
     */
    public void SetCantMove()
    {
        canMove = false;
    }

    /**
     * Sposta la tela in su
     */
    public void MoveUp()
    {
        tela.transform.position += new Vector3(0, 0.5f, 0);
    }

    /**
     * Sposta la tela in giu
     */
    public void MoveDown()
    {
        tela.transform.position -= new Vector3(0, 0.5f, 0);
    }

    /**
     * Sposta la tela a destra
     */
    public void MoveRight()
    {
        tela.transform.position += new Vector3(0.5f, 0, 0);
    }

    /**
     * Sposta la tela a sinistra
     */
    public void MoveLeft()
    {
        tela.transform.position -= new Vector3(0.5f, 0, 0);
    }

    /**
     * Posiziona la tela come era inizialmente
     */
    public void ResetPoition()
    {
        tela.transform.position = oldPosition;
    }
}
