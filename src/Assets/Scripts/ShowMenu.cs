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

    // Indicano se i Canvas sono attivi o disattivati
    private bool showStart;
    private bool showConfig;

    // Bottone presente nella Start_Page, il quale apre il menu di impostazioni di una nuova tela
    public Button nuovoFoglio;

    // Start is called before the first frame update
    void Start()
    {
        // Attiva lo Start_Menu
        showStart = true;
        menu.SetActive(showStart);
        
        // Disattiva il menu delle impostazioni di una nuova tela
        showConfig = false;
        configMenu.SetActive(showConfig);

        // Aggiunge un listener al bottone
        nuovoFoglio = nuovoFoglio.GetComponent<Button>();
        nuovoFoglio.onClick.AddListener(changeConfig);
    }

    // Update is called once per frame
    void Update()
    {
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
