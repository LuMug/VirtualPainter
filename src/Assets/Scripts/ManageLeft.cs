using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLeft : MonoBehaviour
{
	HandModel hand_model;
	Hand leap_hand;
	Controller controller = new Controller();

	public GameObject menu;

	public GameObject rightHand;

	public GameObject actionController;

	private bool isGrabbing;
	private bool isFaceUp;
	private bool isPinching;

	void Start()
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");

		hand_model.UpdateHand();
	}

	void Update()
	{
		try
		{
			if (leap_hand != null && leap_hand.IsLeft)
			{
				if (leap_hand.GrabStrength == 1)
				{
					isGrabbing = true;
				}
				else
				{
					isGrabbing = false;
				}

				if (leap_hand.IsPinching())
				{
					isPinching = true;
				}
				else
				{
					isPinching = false;
				}

				if (leap_hand.PalmNormal.y >= 0)
				{
					menu.SetActive(true);
					isFaceUp = true;
				}
				else
				{
					menu.SetActive(false);
					isFaceUp = false;
				}

				if (isPinching && rightHand.GetComponent<ManageRight>().IsHandPinching())
				{
					double distance = leap_hand.PalmPosition.DistanceTo(rightHand.GetComponent<ManageRight>().GetPalmNormal());
					if (distance > 0.38)
					{
						actionController.GetComponent<Zoom>().ZoomOut();
					}
					else if (distance < 0.2)
					{
						actionController.GetComponent<Zoom>().ZoomIn();
					}
				}

				if (isGrabbing && rightHand.GetComponent<ManageRight>().IsHandGrabbing())
				{
					Debug.Log("Both hand grab");
				}
            }
            else
            {
				menu.SetActive(false);
			}
		}
		catch (NullReferenceException e)
		{
			Debug.LogError("Mani non inserite " + e.Message);
			menu.SetActive(false);
		}
	}
	public bool IsGrabbing()
	{
		return isGrabbing;
	}

	public bool IsFaceUp()
	{
		return isFaceUp;
	}

	public bool IsPinching()
	{
		return isPinching;
	}
}
