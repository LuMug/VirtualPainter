using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Undo : MonoBehaviour
{
    // Salva lo stato della mano (isPinched = true)
    bool last = false;
    // Salva lo stato dei tasti ctrl+z (premuti = true)
    bool pressed = false;
    HandModel hand_model;
    Hand leap_hand;
    List<Texture2D> textures = new List<Texture2D>();
    public GameObject telaDisegnabile;
    void Start()
    {
        hand_model = GetComponent<HandModel>();
        leap_hand = hand_model.GetLeapHand();
    }

    void Update()
    { 
        try
        {
            if (leap_hand != null)
            {
                //Controlla che la mano sia pinchata e che non lo fosse prima e cambia lo stato della manô
                if (leap_hand.IsPinching()&&!last)
                {
                    last = true;
                    Debug.Log("last true");
                }
                //Controlla che la mano non sia più pinchata e aggiunge la texture corrente alla lista
                else if (!leap_hand.IsPinching() && last)
                {
                    last = false;
                    Texture2D texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
                    if (textures.Count == 15)
                    {
                        textures.RemoveAt(0);
                    }
                    textures.Add(Instantiate(texture));
                    Debug.Log("aggiornato ultimo index con mani");
                }
            }

            else if(last)
            {
                last = false;
                Texture2D texture = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;
                if (textures.Count == 15)
                {
                    textures.RemoveAt(0);
                }
                textures.Add(Instantiate(texture));
                Debug.Log("aggiornato ultimo index no mani");
            }

        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Mani non inserite");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Z)&&!pressed)
        {
            Debug.Log(textures.Count);
            pressed = true;
            if (textures.Count > 1)
            {
                textures.RemoveAt(textures.Count - 1);
                var tex = textures.ElementAt(textures.Count - 1);
                telaDisegnabile.GetComponent<Renderer>().material.mainTexture = tex;
                tex.Apply();
            }
        }
        else if(!Input.GetKey(KeyCode.LeftControl) || !Input.GetKey(KeyCode.Z))
        {
            pressed = false;
        }
    }
}
