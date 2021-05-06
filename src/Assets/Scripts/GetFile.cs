using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
// Author: Sara Bressan, Karim Galliciotti e Zeno Darani

/// <summary>
/// La classe <c>GetFile</c> ha lo scopo di applicare sulla tela una texture presa da un file JPG o PNG esterno.
/// </summary>
public class GetFile : MonoBehaviour
{
    /// <summary>
    /// Canvas di Start_menu.
    /// </summary>
    public GameObject menu;

    /// <summary>
    /// Indica se il canvas dello start menu è attivo
    /// </summary>
    private bool showStart;

    /// <summary>
    /// Gestisce i salvataggi del file.
    /// </summary>
    FileManager file;

    /// <summary>
    /// La texture.
    /// </summary>
    Texture2D texture;

    /// <summary>
    /// Piano rappresentante la tela.
    /// </summary>
    public GameObject telaDisegnabile;

    //Bottone per scegliere l'immagine da caricare
    public Button getSheet;

    /// <summary>
    /// La main camera.
    /// </summary>
    public new Camera camera;

    /// <summary>
    /// Gestisce la scala nel quale viene rappresentata la tela.
    /// </summary>
    private AutoSize autoSize = new AutoSize();

    /// <summary>
    /// Metodo eseguito all'avvio dello script.
    /// </summary>
    private void Start()
    {
        // Aggiunge un listener al bottone
        getSheet = getSheet.GetComponent<Button>();
        getSheet.onClick.AddListener(OpenFilePanel);
    }

    /// <summary>
    /// Carica un immagine e nasconde il menu.
    /// </summary>
    public void OpenFilePanel()
    {
        //Filtri per far scegliere all'utente solo immagini
        var extensionsFile = new[] {
            new ExtensionFilter("Image Files", "png", "jpg"),
        };
        //Tutte le path selezionate
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open Image", "", extensionsFile, false);
        //Controlla che sia selezionata solo un'immagine
        if (paths.Length == 1 && File.Exists(paths[0]))
        {
            file = new FileManager(paths[0], FileManager.READ_MODE);
            string json = File.ReadAllText("./paths.json");
            List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
            for (int i = 0; i < oldPaths.Count; i++)
            {
                if (paths[0].Equals(oldPaths[i].path))
                {
                    oldPaths.RemoveAt(i);
                }
            }
            List<Paths> filePath = new List<Paths>();
            filePath = new List<Paths>
            {
                new Paths {path = paths[0]}
            };
            oldPaths.Add(filePath[0]);
            File.WriteAllText("./paths.json", JsonConvert.SerializeObject(oldPaths));
            //Prende l'immagine
            texture = file.GetTexture();
            //La applico sulla tela
            telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
            //Disattiva il menu
            hideMenuStart();
            autoSize.AutoSizeTela(camera, telaDisegnabile, texture.width, texture.height);
        }
    }

    /// <summary>
    /// Disattiva lo Start_Menu.
    /// </summary>
    public void hideMenuStart()
    {
        showStart = false;
        menu.SetActive(showStart);
    }

}
