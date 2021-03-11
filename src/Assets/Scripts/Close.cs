using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Close : MonoBehaviour
{
    private FileManager file;

    public void salvaEdEsci()
    {
        string json = File.ReadAllText("Assets/Models/paths.json");
        List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
        string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths.Count - 3, 3);
        file = new FileManager(oldPaths[oldPaths.Count - 1].path);
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
}
