using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExplorer : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("Pressed");
            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            Debug.Log("Not pressed");
            prevPress = false;
        }
    }
}
