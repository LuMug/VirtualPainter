using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    // File Manager
    private FileManager file;

    // UI del menù di uscita
    public GameObject exitUI;

    // Mani
    public GameObject hands;

    // Bottoni presenti sull'UI
    public Button si;
    public Button no;
    public Button annulla;

    public GameObject colori;
    public GameObject strumenti;

    // Start is called before the first frame update
    private void Start()
    {
        colori.SetActive(false);
        strumenti.SetActive(false);

        si = si.GetComponent<Button>();
        no = no.GetComponent<Button>();
        annulla = annulla.GetComponent<Button>();

        si.onClick.AddListener(salvaEdEsci);
        no.onClick.AddListener(esci);
        annulla.onClick.AddListener(Annulla);
    }

    /// <summary>
    /// Salva la texture in formato "png" o "jpg" e chiude l'applicazione.
    /// </summary>
    public void salvaEdEsci()
    {
        string json = File.ReadAllText("./paths.json");
        List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
        string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
        file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.WRITE_MODE);
        var texture = file.GetTexture();
        if (extension.Equals("png"))
        {
            file.SaveTexturePNG(texture);
        }
        else if (extension.Equals("jpg"))
        {
            file.SaveTextureJPG(texture);
        }
        Application.Quit();
    }
    public void esci()
    {
        Application.Quit();
    }

    public void Annulla()
    {
        exitUI.SetActive(false);
        hands.SetActive(true);
    }
}
