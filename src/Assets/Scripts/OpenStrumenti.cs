using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStrumenti : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress;

    private bool active = false;

    public GameObject instrument;

    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        instrument.SetActive(false);
        button = GetComponent<InteractionButton>();
    }

    private void openStrumenti()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed && !prevPress)
        {
            active = !active;
            instrument.SetActive(active);

            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            prevPress = false;
        }
    }
}
