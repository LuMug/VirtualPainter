using Leap.Unity.Interaction;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// Lo script <c>OpenExplorer</c> serve salvare il disegno.
/// </summary>
public class OpenExplorer : MonoBehaviour
{
    /// <summary>
    /// Corrisponde al bottone di salvataggio presente sul menù inventario.
    /// </summary>
    private InteractionButton button;

    /// <summary>
    /// Indica se il bottone era premuto.
    /// </summary>
    private bool prevPress = false;

    /// <summary>
    /// FileManager che serve a salvare il disegno su file.
    /// </summary>
    private FileManager file;

    /// <summary>
    /// Metodo richiamato una volta alla partenza di questo script (primo frame).
    /// </summary>
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    /// <summary>
    /// Metodo richiamato ad ogni frame.
    /// </summary>
    void Update()
    {
        // Se il bottone viene premuto salva il disegno nell'ultimo file presente in paths.json.
        if (button.isPressed && !prevPress)
        {
            string json = File.ReadAllText("Assets/Models/paths.json");
            List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
            string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
            file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.READ_MODE);
            var texture = file.GetTexture();
            file = new FileManager(oldPaths[oldPaths.Count - 1].path, FileManager.WRITE_MODE);
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
