using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>MoveCanvas</c> serve a muovere la tela rispetto alla telecamera 
/// (ciò che l'utente vede).
/// </summary>
public class MoveCanvas : MonoBehaviour
{
    /// <summary>
    /// Corrisponde all'oggetto Tela.
    /// </summary>
    public GameObject tela;

    /// <summary>
    /// Corrisponde alla posizione originale della tela.
    /// </summary>
    private Vector3 oldPosition;

    /// <summary>
    /// Indica se è possibile muovere la tela.
    /// </summary>
    private bool canMove;

    /// <summary>
    /// Start è un metodo che viene richiamato una volta la prima esecuzione di questo script (primo frame).
    /// </summary>
    void Start()
    {
        // Salva la posizione iniziale della tela rispetto alla telecamera
        oldPosition = tela.transform.position;

    }

    /// <summary>
    /// Update è un metodo che viene richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se si può muovere la tela
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

    /// <summary>
    /// Setta la tela come muovibile.
    /// </summary>
    public void SetCanMove()
    {
        canMove = true;
    }

    /// <summary>
    /// Setta la tela come non muovibile.
    /// </summary>
    public void SetCantMove()
    {
        canMove = false;
    }

    /// <summary>
    /// Sposta la tela verso l'alto.
    /// </summary>
    public void MoveUp()
    {
        tela.transform.position += new Vector3(0, 0.5f, 0);
    }

    /// <summary>
    /// Sposta la tela verso il basso.
    /// </summary>
    public void MoveDown()
    {
        tela.transform.position -= new Vector3(0, 0.5f, 0);
    }

    /// <summary>
    /// Sposta la tela verso destra.
    /// </summary>
    public void MoveRight()
    {
        tela.transform.position += new Vector3(0.5f, 0, 0);
    }

    /// <summary>
    /// Sposta la tela verso sinistra.
    /// </summary>
    public void MoveLeft()
    {
        tela.transform.position -= new Vector3(0.5f, 0, 0);
    }

    /// <summary>
    /// Resetta la posizione della tela nella sua posizione originale.
    /// </summary>
    public void ResetPoition()
    {
        tela.transform.position = oldPosition;
    }
}
