using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

/**
 * Classe utile per manipolare i file per il caricamento ed il
 * salvataggio delle tele in fromato JPG e PNG.
 */
public class FileManager
{
    //il percorso al file
    private string path;
    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    public FileManager(string path)
    {
        Path = path;
    }

    //ritorna la texture ricavata dall'immagine
    public Texture2D GetTexture()
    {
        Texture2D tex = new Texture2D(2,2);
        if(!File.Exists(Path))
        {
            return null;
        }
        byte[] imageBytes = File.ReadAllBytes(Path);
        tex.LoadImage(imageBytes);
        return tex;
    }

    //salva una texture in un formato jpg
    public void SaveTextureJPG(Texture2D tex)
    {
        byte[] imageBytes = ImageConversion.EncodeToJPG(tex);    
        File.WriteAllBytes(Path, imageBytes); 
    }

    public void SaveTexturePNG(Texture2D tex)
    {
        byte[] imageBytes = ImageConversion.EncodeToPNG(tex);    
        File.WriteAllBytes(Path, imageBytes); 
    }
}
