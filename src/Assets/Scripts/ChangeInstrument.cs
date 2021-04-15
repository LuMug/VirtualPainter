using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInstrument : MonoBehaviour
{
    public GameObject rightHand;
    public InteractionButton pen;
    public InteractionButton eraser;
    public InteractionButton fill;

    private bool prevPenPress;
    private bool activePen;

    private bool prevErasePress;
    private bool activeErase;

    private bool prevFillPress;
    private bool activeFill;

    public GameObject colorPicker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pen.isPressed && !prevPenPress)
        {
            activePen = !activePen;
            rightHand.GetComponent<ManageRight>().SetPen();
            prevPenPress = true;
            this.GetComponent<CurrentInstrument>().SetPen();
        }
        else if (!pen.isPressed && prevPenPress)
        {
            prevPenPress = false;
        }

        if (eraser.isPressed && !prevErasePress)
        {
            activeErase = !activeErase;
            colorPicker.SetActive(false);
            rightHand.GetComponent<ManageRight>().SetEraser();
            prevErasePress = true;
            this.GetComponent<CurrentInstrument>().SetEraser();
        }
        else if (!eraser.isPressed && prevErasePress)
        {
            prevErasePress = false;
        }

        if (fill.isPressed && !prevFillPress)
        {
            activeFill = !activeFill;
            prevFillPress = true;
            this.GetComponent<CurrentInstrument>().SetFill();
        }
        else if (!fill.isPressed && prevFillPress)
        {
            prevFillPress = false;
        }
    }
}
