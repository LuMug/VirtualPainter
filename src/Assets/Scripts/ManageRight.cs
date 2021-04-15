using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageRight : MonoBehaviour
{
    public const int MAX_BRUSH_SIZE = 80;
    /** 
	 *  Lo slider che assegna il suo valore alla grandezza del pennello.
	 */
    public InteractionSlider BrushSizeSlider;
    /**
	 * La dimensione del pennello in px.
	 */
    private int brushSize = 10;

    HandModel hand_model;
    Hand leap_hand;
    Controller controller = new Controller();

    public GameObject colorPicker;

    Color color = new Color(0,0,0);

    public GameObject actionController;

    public GameObject leftHand;

    public GameObject tela;

    bool prevPinch = false;

    private bool pinch;
    private bool grab;
    private bool erase;
    private float pinchDistance;
    private Vector palmNormal;

    void Start()
    {
        hand_model = GetComponent<HandModel>();
        leap_hand = hand_model.GetLeapHand();
        if (leap_hand == null) Debug.LogError("No leap_hand founded");

        // assegna l'azione UpdateBrushSize all'evento di movimento dello slider
        BrushSizeSlider.HorizontalSlideEvent = new Action<float>(UpdateBrushSize);

        UpdateBrushSize(BrushSizeSlider.defaultHorizontalValue);
        if (!erase)
        {
            ChangeColor();
        }
        else
        {
            SetEraser();
        }

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (leap_hand != null && leap_hand.IsRight)
            {
                palmNormal = leap_hand.PalmPosition;

                if (leap_hand.IsPinching())
                {
                    pinch = true;
                    pinchDistance = leap_hand.PinchDistance;

                    Draw();
                    //fill();
                }
                else
                {
                    pinch = false;
                    prevPinch = false;

                    //if (leftHand.GetComponent<ManageLeft>().IsFaceUp())
                    //{
                    //    if (leap_hand.PalmNormal.y >= 0.85)
                    //    {
                    //        actionController.GetComponent<Rotate>().RotateRight();
                    //    }
                    //    else if (leap_hand.PalmNormal.y <= -0.7)
                    //    {
                    //        actionController.GetComponent<Rotate>().RotateLeft();
                    //    }
                    //    else if (leap_hand.GrabStrength == 1)
                    //    {
                    //        actionController.GetComponent<Rotate>().NormalizeRotation();
                    //    }
                    //}
                }

                if (leap_hand.GrabStrength == 1)
                {
                    grab = true;
                }
                else
                {
                    grab = false;
                }

            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Mani non inserite " + e.Message);
        }
    }

    public bool IsHandPinching()
    {
        return pinch;
    }

    public bool IsHandGrabbing()
    {
        return grab;
    }

    public float GetPinchDistance()
    {
        return pinchDistance;
    }

    public Vector GetPalmNormal()
    {
        return palmNormal;
    }

    public void Draw()
    {
        //guarda se le dita sono nella giusta posizione
        if (!leftHand.GetComponent<ManageLeft>().IsFaceUp())
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
            Texture2D tex = (Texture2D)tela.GetComponent<Renderer>().material.mainTexture;

            //disegno sulla tela
            tex = DrawCircle(tex, color, (int)(tex.width * (finger.GetTipPosition().x + 0.5)), (int)(tex.height * (finger.GetTipPosition().y - 3.5)), brushSize);
            //Debug.Log("X: " + finger.GetTipPosition().x);
            //Debug.Log("Y: " + finger.GetTipPosition().z);
            //Debug.Log("XT: " + (tex.width * (finger.GetTipPosition().x + width / 2)));
            //Debug.Log("YT: " + (tex.height * (finger.GetTipPosition().z + height / 2)));
            tex.Apply();
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

    /**
	 * Aggiorna la dimensione del pennello.
	 * @param value il valore di moltiplicazione [0;1] della dimensione massima del pennello
	 */
    private void UpdateBrushSize(float value)
    {
        //Debug.Log(value);
        if (value < 0 || value > 1)
        {
            throw new ArgumentOutOfRangeException("Value must be between [0;1]");
        }
        brushSize = (int)Math.Round(value * MAX_BRUSH_SIZE);
        if (brushSize <= 1)
        {
            brushSize = 1;
        }
    }
    public void ChangeColor()
    {
        color = colorPicker.GetComponent<ColorPicker>().SelectedColor;
        GameObject.Find("ActionController").GetComponent<CurrentInstrument>().ChangeColor(color);
    }

    public void SetEraser()
    {
        erase = true;
        color = Color.white;
    }

    public void SetPen()
    {
        erase = false;
        ChangeColor();
    }

    public bool GetEraser()
    {
        return erase;
    }

    public void fill()
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
            Texture2D tex = (Texture2D)tela.GetComponent<Renderer>().material.mainTexture;
            //disegno sulla tela
            Debug.Log("Ciao");
            FloodFill(tex, 1, (int)(tex.width * (finger.GetTipPosition().x + 0.5)), (int)(tex.height * (finger.GetTipPosition().y + 0.5)));
            tex.Apply();
            prevPinch = true;
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
