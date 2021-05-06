using Newtonsoft.Json;
using SFB;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
// Author: Sara Bressan, Zeno Darani, Karim Galliciotti e Stefano Mureddu

/// <summary>
/// Create file serve a creare la tela (texture) e a ridimensionarla.
/// </summary>
public class CreateFile : MonoBehaviour
{
    /// <summary>
    /// Campo dell'interfaccia delle impostazioni della tela nella quale si deve inserire l'altezza della tela
    /// in pixels.
    /// </summary>
    public InputField InputAltezza;

    /// <summary>
    /// Campo dell'interfaccia delle impostazioni della tela nella quale si deve inserire la larghezza della tela
    /// in pixels.
    /// </summary>
    public InputField InputLarghezza;

    /// <summary>
    /// Piano sulla quale è presente la texture (tela) sulla quale si andrà a disegnare.
    /// </summary>
    public GameObject telaDisegnabile;

    /// <summary>
    /// Bottone continua della interfaccia delle impostazioni della tela.
    /// </summary>
    public Button continua;

    /// <summary>
    /// Gestore file il quale salva il disegno / tela.
    /// </summary>
    private FileManager file;

    /// <summary>
    /// Main camera del progetto.
    /// </summary>
    public new Camera camera;

    /// <summary>
    /// Autosize che serve a ridimensionare la tela in modo automatico scalandola in modo che 
    /// appaia sempre riempiendo lo schermo dell'utente.
    /// </summary>
    private AutoSize autoSize = new AutoSize();

    /// <summary>
    /// Oggetto color picker per la selezione dei colori utilizzati per disegnare.
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Pannello per la scelta dello strumento (penna o gomma) attivo.
    /// </summary>
    public GameObject strumenti;

    /// <summary>
    /// Action Controller, GameObject che gestisce i vari script del programma.
    /// </summary>
    public GameObject actionController;

    /// <summary>
    /// Indica se la tela è già stata creata.
    /// </summary>
    private bool alreadyCreated;

    /// <summary>
    /// Start viene eseguito una volta alla partenza dello script.
    /// </summary>
    void Start()
    {
        // Assegnazione del bottone "continua".
        continua = continua.GetComponent<Button>();
        // Nel caso in cui il bottone continua venga selezionato viene richiamato il metodo "CreateNewTela".
        continua.onClick.AddListener(CreateNewTela);

        // Disattiva il ColorPicker.
        colorPicker.SetActive(false);
        // Disattiva il menù strumento attivo.
        strumenti.SetActive(false);
        // Fa in modo che la tela non si muovi nonostante vengano premuti i tasti del numpad assegnati a 
        // questa funzionalità.
        actionController.GetComponent<MoveCanvas>().SetCantMove();

        // Se la tela è già stata creata.
        if (alreadyCreated)
        {
            // Salva il disegno attuale.
            this.GetComponent<OpenSalvaConNome>().Salva();
        }
        // Se la tela non è mai stata creata.
        else
        {
            // Setta la tela come già creata.
            alreadyCreated = true;
        }
    }

    /// <summary>
    ///Crea una nuova texture che viene applicata al piano che funge da tela salvandola in formato jpg o png e in seguito ne salva il
    /// percorso nel file "paths.json".
    /// </summary>
    /// <param name="imageWidth">corrisponde alla larghezza dell'immgine</param>
    /// <param name="imageHeight">corrisponde all'altezza dell'immagine</param>
    public void CreateNew(int imageWidth, int imageHeight)
    {
        // Se la larghezza definita dall'utente è minore di 0.
        if(imageWidth < 0)
        {
            // La larghezza di default è di 100 pixels.
            imageWidth = 100;
        }
        // Se l'altezza definita dall'utente è negativa.
        if(imageHeight < 0)
        {
            // L'altezza di default è di 100 pixels.
            imageHeight = 100;
        }
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

        // Contiene l'estensione del file e lo salva
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
            // Inserisco la oath della nuova texture
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
    public void CreateNewTela()
    {
        // Parsing in intero dell'altezza inserita dall'utente nel menù delle impostazioni della tela.
        int height = Int32.Parse(InputAltezza.text);
        // Parsing in intero della larghezza inserita dall'utente nel menù delle impostazioni della tela.
        int width = Int32.Parse(InputLarghezza.text);
        // Crea una nuova tela a partire dall'altezza e la larghezza definite dall'utente.
        CreateNew(width, height);
    }

    /// <summary>
    /// Trasforma le unità Unity in pixels.
    /// </summary>
    /// <param name="unityValue">valore di Unity da convertire</param>
    /// <returns></returns>
    public static float UnityToPixels(int unityValue)
    {
        return (float)unityValue / 100;
    }

}