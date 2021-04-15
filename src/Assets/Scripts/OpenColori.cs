using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenColori : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress;

    private bool active = false;

    public GameObject colorPicker;

    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        colorPicker.SetActive(false);
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
            colorPicker.SetActive(active);

            if (!active)
            {
                rightHand.GetComponent<ManageRight>().ChangeColor();
            }

            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            prevPress = false;
        }
    }
}
