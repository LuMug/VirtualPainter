using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>StartDrawing</c> serve chiudere le UI di impostazione della tela (UI iniziali)
/// e a far partire la parte di disegno del programma.
/// </summary>
public class StartDrawing : MonoBehaviour
{
    /// <summary>
    /// Corrisponde al canvas start_menu.
    /// </summary>
    public GameObject menu;
    
    /// <summary>
    /// Corrisponde al canvas di configurazione di una nuova tela.
    /// </summary>
    public GameObject configMenu;

    /// <summary>
    /// Bottone per aprire una immagine esistente.
    /// </summary>    
    public Button caricaFoglio;

    /// <summary>
    /// Bottone che serve a creare una nuova tela.
    /// </summary>
    public Button creaNuovaTela;

    /// <summary>
    /// Corrisponde all'oggetto contenente le mani.
    /// </summary>
    public GameObject hands;

    /// <summary>
    /// Corrisponde alla tela disegnabile.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Corrisponde all'oggetto per la gestione del programma.
    /// </summary>
    public GameObject actionController;

    /// <summary>
    /// Metodo che viene richiamato una volta al primo frame.
    /// </summary>
    void Start()
    {
        // Se il bottone di caricamento della tela (nuova o vecchia) viene caricato si possono visualizzare 
        // le mani, mentre i canvas spariscono.
        caricaFoglio.onClick.AddListener(HideCaricamento);
        creaNuovaTela.onClick.AddListener(HideNuovaTela);
    }

    /// <summary>
    /// Metodo che viene richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Mostra la tela e disattiva lo start_menu.
    /// </summary>
    public void HideCaricamento()
    {
        // Nasconde lo start_menu.
        menu.SetActive(false);
        // Mostra le mani e la tela.
        ShowHands();
    }

    /// <summary>
    /// Metodo che nasconde l'UI dove si selezionano le dimensioni della nuova tela e 
    /// </summary>
    public void HideNuovaTela()
    {
        // Disattiva il menu impostazioni.
        configMenu.SetActive(false);
        // Mostra mani e tela.
        ShowHands();
    }

    /// <summary>
    /// Metodo che serve a mostrare le mani e la tela.
    /// </summary>
    public void ShowHands()
    {
        // Attiva le mani.
        hands.SetActive(true);
        // Attiva la possibilità di poter muovere la tela.
        actionController.GetComponent<MoveCanvas>().SetCanMove();
        // Attiva la tela.
        telaDisegnabile.SetActive(true);
    }
}
