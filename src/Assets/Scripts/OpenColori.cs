using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>OpenColori</c> consente di far apparire e sparire il colorPicker
/// con la quale selezionare il colore della penna in uso.
/// </summary>
public class OpenColori : MonoBehaviour
{
    /// <summary>
    /// Bottone "colori" del menù inventario (si tratta del bottone presente sul menù quando si ruota la mano sinistra).
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Indica se il bottone era precedentemente premuto.
    /// </summary>
    private bool prevPress;

    /// <summary>
    /// Indica se il colorPicker è attivo.
    /// </summary>
    private bool active = false;

    /// <summary>
    /// Oggetto colorPicker con la quale selezionare il colore della penna.
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Corrisponde alla mano destra attualmente attiva.
    /// </summary>
    public GameObject rightHand;

    /// <summary>
    /// Metodo che viene richiamato una volta allo start dello script (al primo frame).
    /// </summary>
    void Start()
    {
        // Disattiva il colorPicker
        colorPicker.SetActive(false);
        // Corrisponde al bottone.
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Metodo che viene richiamato ad ogni frame del programma.
    /// </summary>
    void Update()
    {
        // Se il bottone viene premuto
        if (button.isPressed && !prevPress)
        {
            // Se il colorPicker era attivo lo disattiva e viceversa.
            active = !active;
            // Mostra/Nasconde il ColorPicker.
            colorPicker.SetActive(active);

            // Se il ColorPicker viene disattivato
            if (!active)
            {
                // Imposta il colore della penna secondo quanto scelto nel ColorPicker.
                rightHand.GetComponent<ManageRight>().ChangeColor();
            }

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
