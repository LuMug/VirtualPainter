using Leap.Unity.Interaction;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OpenExplorer : MonoBehaviour
{
    /// <summary>
    /// Bottone che permette di aprire l'explorer
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Contiene lo stato del bottone
    /// </summary>
    private bool prevPress = false;

    /// <summary>
    /// Gestisce il salvataggio dei file
    /// </summary>
    private FileManager file;

    /// <summary>
    /// Metodo eseguito all'avvio dello script.
    /// </summary>
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Metodo eseguito ad ogni frame.
    /// </summary>
    void Update()
    {
        //Controlla che il bottone sia premuto e che non lo era come stato precedente
        if (button.isPressed && !prevPress)
        {
            
            string json = File.ReadAllText("Assets/Models/paths.json");
            // Lista dei percorsi delle ultime texture salvate
            List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
            // Stringa contenente l'estensione dell'ultimo file modificato
            string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
            // Prende il file aprendolo in modalità lettura
            file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.READ_MODE);
            var texture = file.GetTexture();
            // Apre il file in modalità scrittura
            file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.WRITE_MODE);
            //Salva il file con la giusta estensione.
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
}
