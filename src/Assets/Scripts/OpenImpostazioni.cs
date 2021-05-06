using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>OpenImpostazioni</c> serve ad aprire il pannello nella quale inserire l'altezza e la larghezza della tela.
/// </summary>
public class OpenImpostazioni : MonoBehaviour
{
    /// <summary>
    /// Bottone del menù inventario delle impostazioni.
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Indica se il bottone era precedentemente premuto.
    /// </summary>
    private bool prevPress;

    /// <summary>
    /// Pannello UI per la selezione delle dimensioni della tela (disegno).
    /// </summary>
    public GameObject configurazione_tela;

    /// <summary>
    /// Oggetto contenente le due mani (dx e sx).
    /// </summary>
    public GameObject hands;

    /// <summary>
    /// Corrisponde alla tela sulla quale si andrà a disegnare.
    /// </summary>
    public GameObject tela;

    /// <summary>
    /// Corrisponde all'oggetto che gestisce gli script del programma (quelli non assegnati ad un oggetto preciso).
    /// </summary>
    public GameObject actionController;

    /// <summary>
    /// Corrisponde al colorPicker tramite la quale selezionare il colore da utilizzare.
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Il metodo start viene eseguito una volta nel primo frame.
    /// </summary>
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Il metodo update viene eseguito ad ogni frame. 
    /// </summary>
    void Update()
    {
        // Se il bottone viene premuto
        if (button.isPressed && !prevPress)
        {
            // Attiva la UI configurazione_tela
            configurazione_tela.SetActive(true);
            // Disattiva le mani (le nasconde).
            hands.SetActive(false);
            // Disattiva la tela.
            tela.SetActive(false);
            // Disattiva il colorPicker
            colorPicker.SetActive(false);
            // Imposta il bottone come premuto
            prevPress = true;
            // Fa in modo che la tela non si muova selezionando i numeri sul NumPad (comandi con la quale solitamente si muove la tela).
            actionController.GetComponent<MoveCanvas>().SetCantMove();
        }
        else if (!button.isPressed && prevPress)
        {
            // Imposta il bottone come non premuto.
            prevPress = false;
        }
    }
}
