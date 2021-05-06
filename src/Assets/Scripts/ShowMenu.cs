using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>ShowMenu</c> parte allo start del programma e gestisce le impostazioni iniziali del programma. 
/// </summary>
public class ShowMenu : MonoBehaviour
{
    /// <summary>
    /// Canvas start_menu nella quale selezionare un'immagine preesistente o creare una nuova tela.
    /// </summary>
    public GameObject menu;
    
    /// <summary>
    /// Canvas delle impostazioni della tela (altezza e larghezza).
    /// </summary>
    public GameObject configMenu;

    /// <summary>
    /// Corrisponde al colorPicker.
    /// </summary>
    public GameObject colorPicker;
    
    /// <summary>
    /// Corrisponde al pannello di bottoni per la selezione dello strumento da utilizzare.
    /// </summary>
    public GameObject instruments;

    /// <summary>
    /// Indica se il start_menu è attivo o disattivo.
    /// </summary>
    private bool showStart;

    /// <summary>
    /// Indica se il canvas delle impostazioni della tela (altezza e larghezza) è attivo o disattivo.
    /// </summary>
    private bool showConfig;

    /// <summary>
    /// Bottone presente nella Start_Page, il quale apre il menu di impostazioni di una nuova tela
    /// </summary>
    public Button nuovoFoglio;

    /// <summary>
    /// Corrisponde all'oggetto contenente le mani.
    /// </summary>
    public GameObject hands;

    /// <summary>
    /// Corrisponde alla tela disegnabile.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Corrisponde all'UI del menù di uscita.
    /// </summary>
    public GameObject exitMenu;

    /// <summary>
    /// Corriponde al pannello informativo del Virtual Painter.
    /// </summary>
    public GameObject info;

    /// <summary>
    /// Indica se l'info panel è attivo o disattivo.
    /// </summary>
    private bool infoState = false;

    /// <summary>
    /// Metodo che viene richiamato una volta prima del primo frame.
    /// </summary>
    void Start()
    {
        // Attiva lo Start_Menu.
        showStart = true;
        menu.SetActive(showStart);
        
        // Disattiva il menu delle impostazioni di una nuova tela.
        showConfig = false;
        configMenu.SetActive(showConfig);

        // Disattiva le mani in partenza.
        hands.SetActive(false);
        
        // Nasconde la tela.
        telaDisegnabile.SetActive(false);

        // Aggiunge un listener al bottone.
        nuovoFoglio = nuovoFoglio.GetComponent<Button>();
        nuovoFoglio.onClick.AddListener(changeConfig);

        // Nasconde il menù di uscita (UI).
        exitMenu.SetActive(false);

        // Nasconde il colorPicker.
        colorPicker.SetActive(false);
        // Nasconde il menu strumenti.
        instruments.SetActive(false);
        // Nasconde il pannello informativo.
        info.SetActive(infoState);

        createJson();
    }

    /// <summary>
    /// Metodo richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se il tasto "i" della tastiera viene premuto
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Se l'info panel è attivo lo disattiva e viceversa
            infoState = !infoState;
            info.SetActive(infoState);
        }
    }

    /// <summary>
    /// Attiva la UI per impostare altezza e larghezza tela e disattiva l'UI attuale.
    /// </summary>
    public void changeConfig()
    {
        // Nasconde il menù di partenza.
        showStart  = false;
        menu.SetActive(showStart);

        // Mostra le impostazioni tela.
        showConfig = true;
        configMenu.SetActive(showConfig);
    }

    /// <summary>
    /// Crea il file json nella quale salvare le paths delle immagini.
    /// </summary>
    public static void createJson()
    {
        // Se il file non esiste
        if (!File.Exists("./paths.json"))
        {
            // Crea il file.
            File.Create("./paths.json");
            // Ci scrive dentro "[]".
            File.WriteAllText("./paths.json", "[]");
        }
        Debug.Log(Path.GetFullPath("./paths.json"));
    }
}
