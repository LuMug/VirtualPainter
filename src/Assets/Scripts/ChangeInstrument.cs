using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author: Sara Bressan

/// <summary>
/// Questo script viene utilizzato dal menù nella quale viene selezionato lo strumento
/// attualmente in uso (penna, gomma o filler).
/// </summary>
public class ChangeInstrument : MonoBehaviour
{
    /// <summary>
    /// Corrisponde alla mano destra.
    /// </summary>
    public GameObject rightHand;

    /// <summary>
    /// Corrisponde al bottone per selezionare lo strumento penna.
    /// </summary>
    public InteractionButton pen;

    /// <summary>
    /// Corrisponde al bottone per selezionare lo strumento gomma.
    /// </summary>
    public InteractionButton eraser;

    /// <summary>
    /// Corrisponde al bottone per selezionare lo strumento filler.
    /// </summary>
    public InteractionButton fill;

    /// <summary>
    /// Mostra se il bottone pen è stato premuto nello scorso ciclo.
    /// </summary>
    private bool prevPenPress;

    /// <summary>
    /// Indica se lo strumento penna è attivo.
    /// </summary>
    private bool activePen;

    /// <summary>
    /// Mostra se il bottone erease è stato premuto nello scorso ciclo.
    /// </summary>
    private bool prevErasePress;

    /// <summary>
    /// Indica se lo strumento gomma è attivo.
    /// </summary>
    private bool activeErase;

    /// <summary>
    /// Mostra se il bottone erease è stato premuto nello scorso ciclo.
    /// </summary>
    private bool prevFillPress;
    /// <summary>
    /// Indica se lo strumento gomma è attivo.
    /// </summary>
    private bool activeFill;

    /// <summary>
    /// Oggetto colorPicker nella quale viene selezionato il colore attivo.
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Parte una volta all'avvio di questo script.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Viene eseguito ad ogni frame del programma.
    /// </summary>
    void Update()
    {
        // Se il bottone penna viene selezionato e prima non era selezionato.
        if (pen.isPressed && !prevPenPress)
        {
            // Attiva/Disattiva la penna.
            activePen = !activePen;
            // Imposta come attivo lo strumento penna per la mano destra.
            rightHand.GetComponent<ManageRight>().SetPen();
            // Imposta il tasto penna come selezionato.
            prevPenPress = true;
            // Mostra l'immagine della penna come strumento attivo (vedi immagine in alto a sinistra della GUI).
            this.GetComponent<CurrentInstrument>().SetPen();
        }
        // Se il tasto penna era premuto ed ora non lo è più.
        else if (!pen.isPressed && prevPenPress)
        {
            // Imposta il tasto penna come non selezionato.
            prevPenPress = false;
        }

        // Se il bottone gomma viene selezionato e prima non era selezionato.
        if (eraser.isPressed && !prevErasePress)
        {
            // Attiva/Disattiva la gomma.
            activeErase = !activeErase;
            // Disattiva il color picker -> siccome la gomma è bianca e non le si può modificare il colore.
            colorPicker.SetActive(false);
            // Imposta come attivo lo strumento gomma per la mano destra.
            rightHand.GetComponent<ManageRight>().SetEraser();
            // Imposta il tasto gomma come selezionato.
            prevErasePress = true;
            // Mostra l'immagine della gomma come strumento attivo (vedi immagine in alto a sinistra della GUI).
            this.GetComponent<CurrentInstrument>().SetEraser();
        }
        // Se il tasto gomma era premuto ed ora non lo è più.
        else if (!eraser.isPressed && prevErasePress)
        {
            // Imposta il tasto penna come non selezionato.
            prevErasePress = false;
        }

        // Il Filler non è più utilizzato siccome generava degli errori e delle latenze durante l'esecuzione.

        //if (fill.isPressed && !prevFillPress)
        //{
        //    activeFill = !activeFill;
        //    prevFillPress = true;
        //    this.GetComponent<CurrentInstrument>().SetFill();
        //}
        //else if (!fill.isPressed && prevFillPress)
        //{
        //    prevFillPress = false;
        //}
    }
}
