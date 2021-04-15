using Leap.Unity.Interaction;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SFB;
using UnityEngine.UI;

public class OpenSalvaConNome : MonoBehaviour
{
    //Bottone per salvare
    public InteractionButton buttonSalva;
    //Bottone per salvare con nome
    public InteractionButton buttonSalvaConNome;
    //Tela su cui disegnare
    public GameObject telaDisegnabile;
    //Controlla che il bottone per salvare sia premuto
    private bool prevPress = false;
    //Controlla che il bottone per salvare con nome sia premuto
    private bool prevPressConNome = false;
    // Bottone "Si" della UI Exit
    public Button saveFromUI;

    private FileManager file;

    // Start is called before the first frame update
    void Start()
    {
        buttonSalva = buttonSalva.GetComponent<InteractionButton>();
        buttonSalvaConNome = buttonSalvaConNome.GetComponent<InteractionButton>();
        saveFromUI.onClick.AddListener(Salva);
    }

    // Update is called once per frame
    void Update()
    {
        //Controlla che il bottone per salvare sia premuto e che non lo era allo stato precedente
        if (buttonSalva.isPressed && !prevPress)
        {
            Salva();
            //Setta lo stato del bottone come attivo
            prevPress = true;
        }
        //Controlla che il bottone non sia premuto e che lo era allo stato precedente
        else if (!buttonSalva.isPressed && prevPress)
        {
            //Setta lo stato del bottone come disattivo
            prevPress = false;
        }

        //Controlla che il bottone per salvare con nome sia premuto e che non lo era allo stato precedente
        if (buttonSalvaConNome.isPressed && !prevPressConNome)
        {
            Texture2D texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
            //Filtri per far scegliere all'utente solo immagini
            var extensionsFile = new[] {
                new ExtensionFilter("Image Files", "png", "jpg"),
            };
            // Apre l'explorer e ritorna la path selezionata
            string filePath = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", extensionsFile);

            file = new FileManager(filePath);

            //ricava l'estensione e controlla in che formato salvare il file
            string extension = filePath.Substring(filePath.Length - 3, 3);
            //salva il file nel formato selezionato
            if (extension.Equals("png"))
            {
                file.SaveTexturePNG(texture);
            }
            else if (extension.Equals("jpg"))
            {
                file.SaveTextureJPG(texture);
            }

            //path da salvare nella lista dei file modificati
            List<Paths> paths = new List<Paths>();
            paths = new List<Paths>
            {
                new Paths {path = filePath}
            };
            //prende tutti i percorsi contenuti nella lista se è presente almeno un percorso, altrimenti ci scrive e basta
            if (File.ReadAllText("Assets/Models/paths.json").Length > 1)
            {
                string json = File.ReadAllText("Assets/Models/paths.json");
                List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
                for (int i = 0; i < oldPaths.Count; i++)
                {
                    if (paths[0].path.Equals(oldPaths[i].path))
                    {
                        oldPaths.RemoveAt(i);
                    }
                }
                oldPaths.Add(paths[0]);
                File.WriteAllText("Assets/Models/paths.json", JsonConvert.SerializeObject(oldPaths));
            }
            else
            {
                File.WriteAllText("Assets/Models/paths.json", JsonConvert.SerializeObject(paths));
            }
            //Setta lo stato del bottone come attivo
            prevPressConNome = true;
        }
        //Controlla che il bottone non sia premuto e che lo era allo stato precedente
        else if (!buttonSalvaConNome.isPressed && prevPressConNome)
        {
            //Setta lo stato del bottone come disattivo
            prevPressConNome = false;
        }
    }

    public void Salva()
    {
        //Prende i percorsi dei file salvati
        string json = File.ReadAllText("Assets/Models/paths.json");
        List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
        //Prende l'estensione dell'ultimo file
        string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
        //Prende l'ultimo file attivo
        file = new FileManager(oldPaths[oldPaths.Count - 1].path);
        //Prende la texture dalla tela
        var texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
        Debug.Log(oldPaths[oldPaths.Count - 1].path);
        //Controlla l'estensione con la quale salvare il file
        if (extension.Equals("png"))
        {
            file.SaveTexturePNG(texture);
        }
        else if (extension.Equals("jpg"))
        {
            file.SaveTextureJPG(texture);
        }
    }
}
