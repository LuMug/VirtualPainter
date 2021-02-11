using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateFile : MonoBehaviour
{
    public InputField InputAltezza;
    public InputField InputLarghezza;
    public GameObject telaDisegnabile;
    public Button continua;

    void Start()
    {
        continua = continua.GetComponent<Button>();
        continua.onClick.AddListener(createNewTela);
    }
    public void createNew(int imageWidth, int imageHeight)
    {
        //oggetto è il nome dell'oggetto usato come tela
        var texture = new Texture2D(imageHeight, imageWidth, TextureFormat.RGBA32, false);
        telaDisegnabile.gameObject.transform.localScale = new Vector3(imageHeight, 0, imageWidth);
        Color color = Color.white;
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        telaDisegnabile.GetComponent<Renderer>().material.mainTexture = texture;
    }

    public void createNewTela()
    {
        //inputAltezza e inputLarghezza sono i nomi dei form da cui prendere i dati
        createNew(Int32.Parse(InputAltezza.text), Int32.Parse(InputLarghezza.text));
    }

}
