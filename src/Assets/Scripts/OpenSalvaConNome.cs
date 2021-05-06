using Leap.Unity.Interaction;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SFB;
using UnityEngine.UI;

/// <summary>
/// La classe <c>OpenSalvaConNome</c> permette di salvare una texture in formato JPG o PNG in nuovo percorso a scelta.
/// Il nuovo percorso verrà salvato nel file paths.json.
/// </summary>
public class OpenSalvaConNome : MonoBehaviour
{
    /// <summary>
    /// Bottone per salvare.
    /// </summary>
    public InteractionButton buttonSalva;

    /// <summary>
    /// Bottone per salvare con nome.
    /// </summary>
    public InteractionButton buttonSalvaConNome;

    /// <summary>
    /// Tela su cui disegnare.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Controlla che il bottone per salvare sia premuto.
    /// </summary>
    private bool prevPress = false;

    /// <summary>
    /// Controlla che il bottone per salvare con nome sia premuto.
    /// </summary>
    private bool prevPressConNome = false;

    /// <summary>
    ///  Bottone "Si" della UI Exit.
    /// </summary>
    public Button saveFromUI;

    /// <summary>
    /// Gestisce il salvataggio dei file.
    /// </summary>
    private FileManager file;

    /// <summary>
    /// Metodo eseguito all'avvio dello script.
    /// </summary>
    void Start()
    {
        buttonSalva = buttonSalva.GetComponent<InteractionButton>();
        buttonSalvaConNome = buttonSalvaConNome.GetComponent<InteractionButton>();
        saveFromUI.onClick.AddListener(Salva);
    }

    /// <summary>
    /// Metodo eseguito ad ogni frame.
    /// </summary>
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

            if (filePath.Length > 0)
            {

                file = new FileManager(filePath, FileManager.WRITE_MODE);

                Debug.Log(filePath);

                //path da salvare nella lista dei file modificati
                List<Paths> paths = new List<Paths>();
                paths = new List<Paths>
                {
                    new Paths {path = filePath}
                };
                //prende tutti i percorsi contenuti nella lista se è presente almeno un percorso, altrimenti ci scrive e basta
                if (File.ReadAllText("./paths.json").Length > 1)
                {
                    string json = File.ReadAllText("./paths.json");
                    List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
                    for (int i = 0; i < oldPaths.Count; i++)
                    {
                        if (paths[0].path.Equals(oldPaths[i].path))
                        {
                            oldPaths.RemoveAt(i);
                        }
                    }
                    oldPaths.Add(paths[0]);
                    File.WriteAllText("./paths.json", JsonConvert.SerializeObject(oldPaths));
                }
                else
                {
                    File.WriteAllText("./paths.json", JsonConvert.SerializeObject(paths));
                }

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

            }
            else
            {
                Debug.Log("Annulla Selezionato");
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

    /// <summary>
    /// Salva la texture nello stesso percorso.
    /// </summary>
    public void Salva()
    {
        //Prende i percorsi dei file salvati
        string json = File.ReadAllText("./paths.json");
        List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
        //Prende l'estensione dell'ultimo file
        string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
        //Prende l'ultimo file attivo
        file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.WRITE_MODE);
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
