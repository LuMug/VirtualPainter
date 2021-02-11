using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class GetLeapFingers : MonoBehaviour
{
	HandModel hand_model;
	Hand leap_hand;
	Controller controller = new Controller();


	void Start()
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
	}

	void Update()
	{
		Frame frame = controller.Frame();
		for (int i = 0; i < frame.Hands.Count; i++)
		{
			Hand leapHand = frame.Hands[i];
            if (leapHand.PalmNormal.y > 0.6)
            {
                Debug.Log("Girato");
            }
        }
	}
}