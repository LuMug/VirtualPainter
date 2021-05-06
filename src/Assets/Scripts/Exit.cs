using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
// Author: Sara Bressan

/// <summary>
/// Attiva menù di uscita dal programma.
/// </summary>
public class Exit : MonoBehaviour
{
    /// <summary>
    /// Bottone "esci" presente del pannello inventario attaccato alla mano sinistra.
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Indica se il bottone "Esci" è stato precedentemente premuto.
    /// </summary>
    private bool prevPress = false;

    /// <summary>
    /// Interfaccia Utente per uscire dal programma (pannello di uscita).
    /// </summary>
    public GameObject exitUI;

    /// <summary>
    /// Oggetto contenente le mani.
    /// </summary>
    public GameObject hands;

    /// <summary>
    /// FileManager che gestisce il salvataggio del disegno in un file pgn o jpeg.
    /// </summary>    
    private FileManager file;

    /// <summary>
    /// Metodo che parte una volta nel primo frame.
    /// </summary>
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Metodo che viene eseguito ad ogni frame del programma.
    /// </summary>
    void Update()
    {
        // Se il bottone viene pressato e prima non era premuto
        if (button.isPressed && !prevPress)
        {
            // Attiva il pannello dove scegliere se si vuole uscire dal programma.
            exitUI.SetActive(true);
            // Fa in modo che le mani non siano più visibili.
            hands.SetActive(false);
            // Setta il bottone come premuto.
            prevPress = true;
        }
        // Se il bottone non è premuto e prima era premuto
        else if(!button.isPressed && prevPress)
        {
            // Setta il bottone come non premuto.
            prevPress = false;
        }
    }
}
