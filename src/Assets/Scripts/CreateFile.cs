﻿using Newtonsoft.Json;
using SFB;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class CreateFile : MonoBehaviour
{
    public InputField InputAltezza;
    public InputField InputLarghezza;
    public GameObject telaDisegnabile;
    public Button continua;
    private FileManager file;
    public new Camera camera;
    private AutoSize autoSize = new AutoSize();
    public GameObject colori;
    public GameObject strumenti;
    public GameObject actionController;

    private bool alreadyCreated;


    void Start()
    {
        continua = continua.GetComponent<Button>();
        continua.onClick.AddListener(createNewTela);

        colori.SetActive(false);
        strumenti.SetActive(false);
        actionController.GetComponent<MoveCanvas>().SetCantMove();

        if (alreadyCreated)
        {
            this.GetComponent<OpenSalvaConNome>().Salva();
        }
        else
        {
            alreadyCreated = true;
        }
    }

    public void createNew(int imageWidth, int imageHeight)
    {
        //oggetto è il nome dell'oggetto usato come tela
        var texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGBA32, false);
        telaDisegnabile.gameObject.transform.localScale = new Vector3(UnityToPixels(imageWidth), 0, UnityToPixels(imageHeight));
        telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
        autoSize.AutoSizeTela(camera, telaDisegnabile, imageWidth, imageHeight);

        //Filtri per far scegliere all'utente solo immagini
        var extensionsFile = new[] {
            new ExtensionFilter("Image Files", "png", "jpg"),
        };
        // Save file
        string filePath = StandaloneFileBrowser.SaveFilePanel("Save File", "", "MySaveFile", extensionsFile);

        file = new FileManager(filePath);

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
            new Paths {path = filePath}
        };
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

    }

    public void createNewTela()
    {
        //inputAltezza e inputLarghezza sono i nomi dei form da cui prendere i dati
        createNew(Int32.Parse(InputLarghezza.text), Int32.Parse(InputAltezza.text));
        actionController.GetComponent<MoveCanvas>().SetCanMove();
    }

    public static float UnityToPixels(int unityValue)
    {
        return (float)unityValue / 100;
    }

}