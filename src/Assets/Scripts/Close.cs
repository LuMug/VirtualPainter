using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Author: Sara Bressan, Karim Galliciotti

/// <summary>
/// Gestore del menù di uscita dal programma.
/// </summary>
public class Close : MonoBehaviour
{
    /// <summary>
    /// File Manager, il quale gestisce il salvataggio e il caricamento della tela/disegno.
    /// </summary>
    private FileManager file;

    /// <summary>
    /// Interfaccia Grafica del menù di uscita dal programma.
    /// </summary>
    public GameObject exitUI;

    /// <summary>
    /// Le mani dell'utente rilevate dal Leap Motion Controller.
    /// </summary>
    public GameObject hands;

    /// <summary>
    /// Bottone che serve a salvare il progetto/tela corrente e uscire dal programma.
    /// </summary>
    public Button si;

    /// <summary>
    /// Bottone che serve ad uscire senza salvare dal programma.
    /// </summary>
    public Button no;

    /// <summary>
    /// Bottone che serve a tornare alla tela senza uscire dal programma.
    /// </summary>
    public Button annulla;

    /// <summary>
    /// Corrisponde al color picker con la quale si scelgono i colori da utilizzare per disegnare.
    /// </summary>
    public GameObject colorPicker;

    /// <summary>
    /// Pannello contenente la selezione dello strumento corrente e la grandezza della penna.
    /// </summary>
    public GameObject strumenti;

    /// <summary>
    /// Lo start viene eseguito una volta alla partenza dello script.
    /// </summary>
    private void Start()
    {
        // Disattiva il color picker.
        colorPicker.SetActive(false);
        // Disattiva il pannello strumenti.
        strumenti.SetActive(false);

        // Assegnazione del bottone "si".
        si = si.GetComponent<Button>();
        // Assegnazine del bottone "no".
        no = no.GetComponent<Button>();
        // Assegnazione del bottone "annulla".
        annulla = annulla.GetComponent<Button>();

        // Se il bottone "si" viene premuto viene richiamto il metodo "salvaEdEsci".
        si.onClick.AddListener(SalvaEdEsci);
        // Se il bottone "no" viene premuto viene richiamato il metodo "esci".
        no.onClick.AddListener(Esci);
        // Se il bottone "annulla viene premunto viene richiamato il emtodo "annulla".
        annulla.onClick.AddListener(Annulla);
    }

    /// <summary>
    /// Salva la texture in formato "png" o "jpg" e chiude l'applicazione.
    /// </summary>
    public void SalvaEdEsci()
    {
        // Legge il contenuto del file paths.
        string json = File.ReadAllText("./paths.json");
        // Crea una lista di Paths deserializzando le Paths a partire dal file json.
        List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
        // Prende l'estenzione dell'ultimo file utilizzato (ultimo file del file json).
        string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
        // Apre l'ultimo file (tela/immagine) presente nel file json in modalità scrittura.
        file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.WRITE_MODE);
        // Prende la texture (tela).
        var texture = file.GetTexture();
        // Se l'ultima immagine era un file png
        if (extension.Equals("png"))
        {
            // Salva il disegno come file png.
            file.SaveTexturePNG(texture);
        }
        // Se l'ultima immagine era un file png
        else if (extension.Equals("jpg"))
        {
            // Salva il disegno come un file jpg.
            file.SaveTextureJPG(texture);
        }
        // Esce dall'applicazione.
        Application.Quit();
    }

    /// <summary>
    /// Esce dall'applicazione.
    /// </summary>
    public void Esci()
    {
        // Esce dall'applicazione.
        Application.Quit();
    }

    /// <summary>
    /// Annulla l'uscita dall'applicazione.
    /// </summary>
    public void Annulla()
    {
        // Disattiva il menù di uscita.
        exitUI.SetActive(false);
        // Attiva la visualizzazione delle mani.
        hands.SetActive(true);
    }
}
