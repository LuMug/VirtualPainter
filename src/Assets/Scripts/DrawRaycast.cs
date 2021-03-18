using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System;
using System.Collections.Generic;

public class DrawRaycast : MonoBehaviour
{
	HandModel hand_model;
	Hand leap_hand;
	Controller controller = new Controller();
	Color color = Color.blue;

	public GameObject telaDisegnabile;
	void Start()
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
	}

	void Update()
	{
		try
		{
			if (leap_hand != null)
			{
				float width = telaDisegnabile.GetComponent<Renderer>().bounds.size.x;
				float height = telaDisegnabile.GetComponent<Renderer>().bounds.size.y;
				if (leap_hand.IsPinching())
                {
					FingerModel finger = hand_model.fingers[1];
					RaycastHit hit;
					if (Physics.Raycast(finger.GetTipPosition(), Vector3.forward, 1000))
					{
						Debug.Log("Tela colpita");
						Debug.DrawRay(finger.GetTipPosition(), Vector3.forward, Color.red);
					}
					Texture2D tex = (Texture2D)telaDisegnabile.GetComponent<Renderer>().material.mainTexture;

					tex = DrawCircle(tex, color, (int)(tex.width * (finger.GetTipPosition().x + 0.5)), (int)(tex.height * (finger.GetTipPosition().y - 3.5)), 10);
                    Debug.Log("X: " + finger.GetTipPosition().x);
                    Debug.Log("Y: " + finger.GetTipPosition().z);
					Debug.Log("XT: " + (tex.width * (finger.GetTipPosition().x + width / 2)));
					Debug.Log("YT: " + (tex.height * (finger.GetTipPosition().z + height / 2)));
					tex.Apply();
				}
				
			}
        }
        catch (NullReferenceException e)
        {
			Debug.LogError("Mani non inserite");
        }
	}

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
}