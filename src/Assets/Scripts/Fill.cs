using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
	HandModel hand_model;
	Hand leap_hand;
	Controller controller = new Controller();
	public GameObject telaDisegnabile;
	bool prevPinch = false;
	// Start is called before the first frame update
	void Start()
    {
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
	}

    // Update is called once per frame
    void Update()
    {
        try
		{
			if (leap_hand != null)
			{
				//guarda se le dita sono nella giusta posizione
				if (leap_hand.IsPinching() && !prevPinch)
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
					Debug.Log("Ciao");
					FloodFill(tex, 1, (int)(tex.width * (finger.GetTipPosition().x + 0.5)), (int)(tex.height * (finger.GetTipPosition().y + 0.5)));
					tex.Apply();
					prevPinch = true;
				}

			}
			else if (!leap_hand.IsPinching() && prevPinch)
            {
				prevPinch = false;
            }
		}
		catch (NullReferenceException e)
		{
			Debug.LogError("Mani non inserite");
		}
    }

	public struct Point
	{

		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static void FloodFill(Texture2D texture, float tollerance, int x, int y)
	{
		var targetColor = Color.red;
		var sourceColor = texture.GetPixel(x, y);
		var q = new Queue<Point>(texture.width * texture.height);
		q.Enqueue(new Point(x, y));
		int iterations = 0;

		var width = texture.width;
		var height = texture.height;
		while (q.Count > 0)
		{
			var point = q.Dequeue();
			var x1 = point.x;
            var y1 = point.y;
			Debug.Log("B");
			if (q.Count > width * height)
            {
                throw new System.Exception("The algorithm is probably looping. Queue size: " + q.Count);
            }
			Debug.Log("C");

			if (texture.GetPixel(x1, y1) == targetColor)
			{
				continue;
			}

			texture.SetPixel(x1, y1, targetColor);


			var newPoint = new Point(x1 + 1, y1);
			if (CheckValidity(texture, texture.width, texture.height, newPoint, sourceColor, tollerance) && !q.Contains(newPoint))
				q.Enqueue(newPoint);

			newPoint = new Point(x1 - 1, y1);
			if (CheckValidity(texture, texture.width, texture.height, newPoint, sourceColor, tollerance) && !q.Contains(newPoint))
				q.Enqueue(newPoint);

			newPoint = new Point(x1, y1 + 1);
			if (CheckValidity(texture, texture.width, texture.height, newPoint, sourceColor, tollerance) && !q.Contains(newPoint))
				q.Enqueue(newPoint);

			newPoint = new Point(x1, y1 - 1);
			if (CheckValidity(texture, texture.width, texture.height, newPoint, sourceColor, tollerance) && !q.Contains(newPoint))
				q.Enqueue(newPoint);

			iterations++;
		}
	}

	static bool CheckValidity(Texture2D texture, int width, int height, Point p, Color sourceColor, float tollerance)
	{
		Debug.Log("A");
		if (p.x < 0 || p.x >= width)
		{
            Debug.Log("false1");
            return false;
		}
		if (p.y < 0 || p.y >= height)
		{
            Debug.Log(p.y);
            return false;
		}

		var color = texture.GetPixel(p.x, p.y);

		var distance = Mathf.Abs(color.r - sourceColor.r) + Mathf.Abs(color.g - sourceColor.g) + Mathf.Abs(color.b - sourceColor.b);

        Debug.Log(distance);

        return distance <= tollerance;
	}
}
