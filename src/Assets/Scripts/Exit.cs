using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed && !prevPress)
        {
            Application.Quit();
            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            prevPress = false;
        }
    }
}
