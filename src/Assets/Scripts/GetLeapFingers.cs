using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using System;

public class GetLeapFingers : MonoBehaviour
{
	HandModel hand_model;
	Hand leap_hand;
	Controller controller = new Controller();

	public GameObject menu;

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
				if (leap_hand.PalmNormal.y >= 0)
				{
					menu.SetActive(true);
				}
				else
				{
					menu.SetActive(false);
				}
			}
        }
        catch (NullReferenceException e)
        {
			Debug.LogError("Mani non inserite");
        }
	}
}