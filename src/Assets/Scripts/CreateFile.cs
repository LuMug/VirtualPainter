using Newtonsoft.Json;
using SFB;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// La classe <c>CreateFile</c> ha lo scopo di creare una nuova tela con texture bianca.
/// </summary>
public class CreateFile : MonoBehaviour
{
    /// <summary>
    /// L'altezza della tela in pixel.
    /// </summary>
    public InputField InputAltezza;

    /// <summary>
    /// La larghezza della tela in pixel
    /// </summary>
    public InputField InputLarghezza;

    /// <summary>
    /// La tela su cui disegnare.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Il bottone che permette di cominciare a disegnare.
    /// </summary>
    public Button continua;

    /// <summary>
    /// Gestisce il salvataggio del file.
    /// </summary>
    private FileManager file;

    /// <summary>
    /// La main camera.
    /// </summary>
    public new Camera camera;

    /// <summary>
    /// Gestisce la scala nel quale viene rappresentata la tela.
    /// </summary>
    private AutoSize autoSize = new AutoSize();

    /// <summary>
    /// La tavola dei colori.
    /// </summary>
    public GameObject colori;

    /// <summary>
    /// Menu di selezione dei strumenti
    /// </summary>
    public GameObject strumenti;

    /// <summary>
    /// Controller delle azioni.
    /// </summary>
    public GameObject actionController;

    /// <summary>
    /// Contiene lo stato della tela (Creata = true)
    /// </summary>
    private bool alreadyCreated;

    /// <summary>
    /// Metodo eseguito all'avvio dell'applicazione.
    /// </summary>
    void Start()
    {

        continua = continua.GetComponent<Button>();
        continua.onClick.AddListener(createNewTela);

        colori.SetActive(false);
        strumenti.SetActive(false);
        actionController.GetComponent<MoveCanvas>().SetCantMove();

        // Controlla che la texture sia già stata creata
        if (alreadyCreated)
        {
            this.GetComponent<OpenSalvaConNome>().Salva();
        }
        else
        {
            alreadyCreated = true;
        }
    }
    /// <summary>
    /// Crea una nuova texture che viene applicata al piano che funge da tela salvandola in formato jpg o png e in seguito ne salva il
    /// percorso nel file "paths.json".
    /// </summary>
    /// <param name="imageWidth">larghezza della texture in pixel</param>
    /// <param name="imageHeight">altezza della texture in pixel</param>
    public void createNew(int imageWidth, int imageHeight)
    {
        // Crea la texture
        var texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGBA32, false);
        telaDisegnabile.gameObject.transform.localScale = new Vector3(UnityToPixels(imageWidth), 0, UnityToPixels(imageHeight));
        telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
        // Setta tutti i colori del pixel a bianco
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
        // Adatta la dimensione della tela
        autoSize.AutoSizeTela(camera, telaDisegnabile, imageWidth, imageHeight);

        //Filtri per far scegliere all'utente solo immagini
        var extensionsFile = new[] {
            new ExtensionFilter("Image Files", "png", "jpg"),
        };
        // Save file
        string filePath = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", extensionsFile);
        // Apre il file della texture in modalità scrittura
        file = new FileManager(filePath, FileManager.WRITE_MODE);
        //Contiene l'estensione del file e lo salva
        string extension = filePath.Substring(filePath.Length - 3, 3);
        if (extension.Equals("png"))
        {
            file.SaveTexturePNG(texture);
        }
        else if (extension.Equals("jpg"))
        {
            file.SaveTextureJPG(texture);
        }
        
        List<Paths> paths = new List<Paths>();
        paths = new List<Paths>
        {
            // Inserisco la path della nuova texture
            new Paths {path = filePath}
        };
        // Controlla che la lista contenga almeno un percorso, altrimenti inserisce direttamente la path nella lista
        if (File.ReadAllText("./paths.json").Length > 1)
        {
            // Prende la lista dei percorsi
            string json = File.ReadAllText("./paths.json");
            List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
            // Controlla che nella lista non esista già lo stesso percorso, se si la rimuove
            for (int i = 0; i < oldPaths.Count; i++)
            {
                if (paths[0].path.Equals(oldPaths[i].path))
                {
                    oldPaths.RemoveAt(i);
                }
            }
            // Aggiunge la path alla lista
            oldPaths.Add(paths[0]);
            File.WriteAllText("./paths.json", JsonConvert.SerializeObject(oldPaths));
        }
        else
        {
            File.WriteAllText("./paths.json", JsonConvert.SerializeObject(paths));
        }

    }

    /// <summary>
    /// Crea una nuova tela.
    /// </summary>
    public void createNewTela()
    {
        //inputAltezza e inputLarghezza sono i nomi dei form da cui prendere i dati
        createNew(Int32.Parse(InputLarghezza.text), Int32.Parse(InputAltezza.text));
        actionController.GetComponent<MoveCanvas>().SetCanMove();
    }

    /// <summary>
    /// Converte il valore nella scala di unity.
    /// </summary>
    /// <param name="unityValue"></param>
    /// <returns></returns>
    public static float UnityToPixels(int unityValue)
    {
        return (float)unityValue / 100;
    }

}