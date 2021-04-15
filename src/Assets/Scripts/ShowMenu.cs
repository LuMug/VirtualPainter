using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    // Canvas di Start_menu
    public GameObject menu;
    // Canvas di configurazione di una nuova tela
    public GameObject configMenu;

    // ColorPicker
    public GameObject colorPicker;
    // Menu strumenti
    public GameObject instruments;

    // Indicano se i Canvas sono attivi o disattivati
    private bool showStart;
    private bool showConfig;

    // Bottone presente nella Start_Page, il quale apre il menu di impostazioni di una nuova tela
    public Button nuovoFoglio;

    // Corrisponde alle mani
    public GameObject hands;

    // Corrisponde alla tela disegnabile
    public GameObject telaDisegnabile;

    // Corrisponde al menù di uscita
    public GameObject exitMenu;

    // informazioni sul virtual painter
    public GameObject info;
    private bool infoState = false;

    // Start is called before the first frame update
    void Start()
    {
        // Attiva lo Start_Menu
        showStart = true;
        menu.SetActive(showStart);
        
        // Disattiva il menu delle impostazioni di una nuova tela
        showConfig = false;
        configMenu.SetActive(showConfig);

        // Disattiva le mani in partenza
        hands.SetActive(false);

        // Nasconde la tela
        telaDisegnabile.SetActive(false);

        // Aggiunge un listener al bottone
        nuovoFoglio = nuovoFoglio.GetComponent<Button>();
        nuovoFoglio.onClick.AddListener(changeConfig);

        // Nasconde il menù di uscita (UI)
        exitMenu.SetActive(false);

        colorPicker.SetActive(false);
        instruments.SetActive(false);
        info.SetActive(infoState);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            infoState = !infoState;
            info.SetActive(infoState);
        }
    }

    // Attiva il menu del foglio e disattiva lo Start_Menu
    public void changeConfig()
    {
        showStart  = false;
        menu.SetActive(showStart);

        showConfig = true;
        configMenu.SetActive(showConfig);
    }
}
