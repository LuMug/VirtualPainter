using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDrawing : MonoBehaviour
{
    // Canvas di Start_menu
    public GameObject menu;
    // Canvas di configurazione di una nuova tela
    public GameObject configMenu;

    // Corrisponde al 
    public Button caricaFoglio;
    public Button creaNuovaTela;

    // Corrisponde alle mani
    public GameObject hands;

    // Corrisponde alla tela disegnabile
    public GameObject telaDisegnabile;

    // Start is called before the first frame update
    void Start()
    {
        // Se il bottone di caricamento della tela (nuova o vecchia) viene caricato si possono visualizzare 
        // le mani, mentre i canvas spariscono.
        caricaFoglio.onClick.AddListener(HideCaricamento);
        creaNuovaTela.onClick.AddListener(HideNuovaTela);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideCaricamento()
    {
        menu.SetActive(false);
        ShowHands();
    }

    public void HideNuovaTela()
    {
        configMenu.SetActive(false);
        ShowHands();
    }

    public void ShowHands()
    {
        hands.SetActive(true);
        telaDisegnabile.SetActive(true);
    }
}
