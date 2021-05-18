using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System;
using System.Collections.Generic;
using Leap.Unity.Interaction;

// Author: Karim Galliciotti, Stefano Mureddu, Zeno Darani

/// <summary>
/// La classe <c>DrawRayCast</c> contiene funzionalità per poter disegnare usando il LeapMotion.
/// </summary>
public class DrawRayCast : MonoBehaviour
{
	/// <summary>
    /// Dimensione massima del pennello.
    /// </summary>
	public const int MAX_BRUSH_SIZE = 100;
	/// <summary>
	/// Lo slider che assegna il suo valore alla grandezza del pennello.
	/// </summary>
	public InteractionSlider BrushSizeSlider;
	/// <summary>
	/// La dimensione del pennello in px.
	/// </summary>
	private int brushSize = 10;
	/// <summary>
    /// Contenitore delle mani.
    /// </summary>
	HandModel hand_model;
	/// <summary>
    /// La mano.
    /// </summary>
	Hand leap_hand;
	/// <summary>
    /// Il controller delle mani.
    /// </summary>
	Controller controller = new Controller();
	/// <summary>
    /// Il colore del pennarello.
    /// </summary>
	Color color = Color.black;
	/// <summary>
    /// La tela su cui disegnare.
    /// </summary>
	public GameObject telaDisegnabile;
	/// <summary>
    /// La mano sinistra.
    /// </summary>
	public GameObject leftHand;

	/// <summary>
    /// Meteodo eseguito all'avvio dello script.
    /// </summary>
	void Start()
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
		// assegna l'azione UpdateBrushSize all'evento di movimento dello slider
		BrushSizeSlider.HorizontalSlideEvent = new Action<float>(UpdateBrushSize);

	}
	/// <summary>
    /// Metodo eseguito ad ogni frame.
    /// </summary>
	void Update()
	{
		try
		{
			if (leap_hand != null)
			{
				//prende le dimensione della tela
				float width = telaDisegnabile.GetComponent<Renderer>().bounds.size.x;
				float height = telaDisegnabile.GetComponent<Renderer>().bounds.size.y;
				//guarda se le dita sono nella giusta posizione
				if (leap_hand.IsPinching() && !leftHand.GetComponent<ManageLeft>().IsFaceUp() && !leftHand.GetComponent<ManageLeft>().IsGrabbing() &&
					!leftHand.GetComponent<ManageLeft>().IsPinching())
				{
					//prende come riferimento il dito indice
					FingerModel finger = hand_model.fingers[1];
					RaycastHit hit;
					//guardo se il raycost colpisce la tela
					if (Physics.Raycast(finger.GetTipPosition(), Vector3.forward, 1000))
					{
						Debug.Log("Tela colpita");
						//prendo la posizone del punto in cui è stata colpita la tela
						Debug.DrawRay(finger.GetTipPosition(), Vector3.forward, Color.red);
					}
					//prendo la texture dalla tela
					Texture2D tex = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;

					//disegno sulla tela
					tex = DrawCircle(tex, color, (int)(tex.width * (finger.GetTipPosition().x + 0.5)), (int)(tex.height * (finger.GetTipPosition().y - 3.5)), brushSize);
					//Debug.Log("X: " + finger.GetTipPosition().x);
					//Debug.Log("Y: " + finger.GetTipPosition().z);
					//Debug.Log("XT: " + (tex.width * (finger.GetTipPosition().x + width / 2)));
					//Debug.Log("YT: " + (tex.height * (finger.GetTipPosition().z + height / 2)));
					tex.Apply();
				}

			}
		}
		catch (NullReferenceException e)
		{
			Debug.LogError("Mani non inserite");
		}
	}

	/// <summary>
    /// Disegna un pallino di raggio "radius" in un punto.
    /// </summary>
    /// <param name="tex">la texture su cui disegnare</param>
    /// <param name="color">il colore da disegnare</param>
    /// <param name="x">coordinata x del centro del pallino</param>
    /// <param name="y">coordinata y del centro del pallini</param>
    /// <param name="radius">raggio del pallino</param>
    /// <returns></returns>
	public Texture2D DrawCircle(Texture2D tex, Color color, int x, int y, int radius)
	{
		//Debug.Log("X: " + x);
		//Debug.Log("Y: " + y);
		float rSquared = radius * radius;
		for (int u = x - radius; u < x + radius + 1; u++)
		{
			for (int v = y - radius; v < y + radius + 1; v++)
			{
				if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
					tex.SetPixel(u, v, color);
			}
		}
		return tex;
	}

	/// <summary>
    /// Modifica la grandezza del pennarello
    /// </summary>
    /// <param name="value">la grandezza del pennarello</param>
	private void UpdateBrushSize(float value)
	{
		Debug.Log(value);
		if (value < 0 || value > 1)
		{
			throw new ArgumentOutOfRangeException("Value must be between [0;1]");
		}
		brushSize = (int)Math.Round(value * MAX_BRUSH_SIZE);
		if (brushSize <= 1)
		{
			brushSize = 1;
		}
	}
}
