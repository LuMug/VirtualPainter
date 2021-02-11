using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class GetFile : MonoBehaviour
{
    // Canvas di Start_menu
    public GameObject menu;

    //Indica se il canvas dello start menu è attivo
    private bool showStart;

    FileManager file;
    Texture2D texture;

    //Piano rappresentante la tela
    public GameObject telaDisegnabile;

    //Bottone per scegliere l'immagine da caricare
    public Button getSheet;

    // Start is called before the first frame update
    private void Start()
    {
        // Aggiunge un listener al bottone
        getSheet = getSheet.GetComponent<Button>();
        getSheet.onClick.AddListener(OpenFilePanel);
    }

    //Carica un immagine e nasconde il menu
    public void OpenFilePanel()
    {
        //Filtri per far scegliere all'utente solo immagini
        var extensionsFile = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
        };
        //Tutte le path selezionate
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open Image", "", extensionsFile, false);
        //Controlla che sia selezionata solo un'immagine
        if (paths.Length == 1 && File.Exists(paths[0]))
        {
            file = new FileManager(paths[0]);
            //Prende l'immagine
            texture = file.GetTexture();
            //La applico sulla tela
            telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
            //Disattiva il menu
            hideMenuStart();
        }
    }

    //Disattiva lo Start_Menu
    public void hideMenuStart()
    {
        showStart = false;
        menu.SetActive(showStart);
    }

}
