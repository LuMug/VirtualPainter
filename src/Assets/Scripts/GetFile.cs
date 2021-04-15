using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

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

    public new Camera camera;

    private AutoSize autoSize = new AutoSize();

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
            new ExtensionFilter("Image Files", "png", "jpg"),
        };
        //Tutte le path selezionate
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Open Image", "", extensionsFile, false);
        //Controlla che sia selezionata solo un'immagine
        if (paths.Length == 1 && File.Exists(paths[0]))
        {
            file = new FileManager(paths[0]);
            string json = File.ReadAllText("Assets/Models/paths.json");
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
            File.WriteAllText("Assets/Models/paths.json", JsonConvert.SerializeObject(oldPaths));
            //Prende l'immagine
            texture = file.GetTexture();
            //La applico sulla tela
            telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
            //Disattiva il menu
            hideMenuStart();
            autoSize.AutoSizeTela(camera, telaDisegnabile, texture.width, texture.height);
        }
    }

    //Disattiva lo Start_Menu
    public void hideMenuStart()
    {
        showStart = false;
        menu.SetActive(showStart);
    }

}
