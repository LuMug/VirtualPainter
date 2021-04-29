using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Zeno Darani, Sara Bressan, Karim Galliciotti, Stefano Mureddu

/// <summary>
/// 
/// </summary>
public class ManageRight : HandTransitionBehavior
{
    /// <summary>
    /// La dimensione massima del pennello.
    /// </summary>
    public const int MAX_BRUSH_SIZE = 80;
    /// <summary>
    /// Lo slider che assegna il suo valore alla grandezza del pennello.
    /// </summary>
    public InteractionSlider BrushSizeSlider;
    /// <summary>
    /// La dimensione del pennello in px.
    /// </summary>
    private int brushSize = 10;
    /// <summary>
    /// Il contenitore delle mani.
    /// </summary>
    HandModel hand_model;
    /// <summary>
    /// La mano.
    /// </summary>
    Hand leap_hand;
    /// <summary>
    /// Il controller delle mani.
    /// </summary>
    Controller controller = new Controller();
    /// <summary>
    /// Menù di selezione del colore.
    /// </summary>
    public GameObject colorPicker;
    /// <summary>
    /// Il colore del pennarello
    /// </summary>
    Color color = new Color(0,0,0);
    /// <summary>
    /// Controller delle azioni
    /// </summary>
    public GameObject actionController;
    /// <summary>
    /// La mano sinistra
    /// </summary>
    public GameObject leftHand;
    /// <summary>
    /// Piano su cui si applica a tela.
    /// </summary>
    public GameObject tela;
    /// <summary>
    /// Contiene lo stato precedente della mano.
    /// </summary>
    bool prevPinch = false;
    /// <summary>
    /// Contiene lo stato di pinch attuale della mano
    /// </summary>
    private bool pinch;
    /// <summary>
    /// Contiene lo stato di grab attuale della mano
    /// </summary>
    private bool grab;
    /// <summary>
    /// Contiene lo stato della gomma
    /// </summary>
    private bool erase;
    /// <summary>
    /// La distanza delle dita pinchate
    /// </summary>
    private float pinchDistance;
    /// <summary>
    /// La posizione della mano
    /// </summary>
    private Vector palmNormal;
    /// <summary>
    /// 
    /// </summary>
    private bool handIn;
    /// <summary>
    /// La grandezza del pennarello compreso tra 0 e 1.
    /// </summary>
    private float brushValue;

    /// <summary>
    /// Meteodo eseguito all'avvio dell'applicazione.
    /// </summary>
    void Start()
    {
        hand_model = this.GetComponent<RigidHand>();
        leap_hand = hand_model.GetLeapHand();
        if (leap_hand == null) Debug.LogError("No leap_hand founded");

        // assegna l'azione UpdateBrushSize all'evento di movimento dello slider
        BrushSizeSlider.HorizontalSlideEvent = new Action<float>(UpdateBrushSize);

        // Debugging code
        Texture2D tt = (Texture2D)tela.GetComponent<Renderer>().material.mainTexture;
        //DrawCircle(tt,Color.black, 0, 0, 10);
    }

    /// <summary>
    /// Metodo eseguuto ad ogni frame.
    /// </summary>
    void Update()
    {
        leap_hand = hand_model.GetLeapHand();
        if (leap_hand == null) Debug.LogError("No leap_hand founded");

        try
        {
            if (handIn)
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

    /// <summary>
    /// Ritorna se la mano è pinchata
    /// </summary>
    /// <returns>lo stato di pinching della mano</returns>
    public bool IsHandPinching()
    {
        return pinch;
    }
    /// <summary>
    /// Ritorna se la mano è totalmente chiusa (pugno)
    /// </summary>
    /// <returns>ritorna lo stato di grab della mano</returns>
    public bool IsHandGrabbing()
    {
        return grab;
    }
    /// <summary>
    /// Ritorna la distanza fra la dita pinchate
    /// </summary>
    /// <returns>la distanza fra le dita pinchate</returns>
    public float GetPinchDistance()
    {
        return pinchDistance;
    }
    /// <summary>
    /// Ritorna la posizione della mano
    /// </summary>
    /// <returns>la posizione della mano</returns>
    public Vector GetPalmNormal()
    {
        return palmNormal;
    }
    /// <summary>
    /// Disegna prendendo il dito indice come riferimento.
    /// </summary>
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

    /// <summary>
    /// Disegna un pallino di raggio "radius" in un punto.
    /// </summary>
    /// <param name="tex">texture su cui disegnare</param>
    /// <param name="color">colore del pennello</param>
    /// <param name="x">coordinata x del punto in cui disegnare</param>
    /// <param name="y">coordinata y del punto in cui disegnare</param>
    /// <param name="radius">raggio del pallino</param>
    /// <returns></returns>
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
                {
                    tex.SetPixel(u, v, color);
                    //Debug.Log(u);
                }
            }
        }
        return tex;
    }

    /// <summary>
    /// Aggiorna la dimensione del pennello.
    /// </summary>
    /// <param name="value">il valore di moltiplicazione [0;1] della dimensione massima del pennello</param>
    private void UpdateBrushSize(float value)
    {
        brushValue = value;
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
    /// <summary>
    /// Cambia il colore del pennello.
    /// </summary>
    public void ChangeColor()
    {
        color = colorPicker.GetComponent<ColorPicker>().SelectedColor;
        GameObject.Find("ActionController").GetComponent<CurrentInstrument>().ChangeColor(color);
    }
    /// <summary>
    /// Imposta la gomma come strumento attivo.
    /// </summary>
    public void SetEraser()
    {
        erase = true;
        color = Color.white;
    }
    /// <summary>
    /// Imposta il pennello come strumento attivo.
    /// </summary>
    public void SetPen()
    {
        erase = false;
        ChangeColor();
    }
    /// <summary>
    /// Ritorna lo stato delle gomma (attivo/disattivo)
    /// </summary>
    /// <returns>lo stato della gomma</returns>
    public bool GetEraser()
    {
        return erase;
    }
    /// <summary>
    /// Effettua l'azione di riempimento.
    /// </summary>
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

    /// <summary>
    /// Rappresentazione di un punto
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Coordinata x di un punto.
        /// </summary>
        public int x;
        /// <summary>
        /// Coordinata y di un punto.
        /// </summary>
        public int y;
        /// <summary>
        /// Istanzia le caratteristiche di un punto
        /// </summary>
        /// <param name="x">coordinata x di un punto</param>
        /// <param name="y">coordinata y di un punto</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    /// <summary>
    /// Algoritmo utile per il riempimento
    /// </summary>
    /// <param name="texture">la texture su cui disegnare</param>
    /// <param name="tollerance">valore che determina quanto un valore rgb può cambiare per essere preso in considerazione</param>
    /// <param name="x">coordinata x di un punto</param>
    /// <param name="y">coordinata y di un punto</param>
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="p"></param>
    /// <param name="sourceColor"></param>
    /// <param name="tollerance"></param>
    /// <returns></returns>
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

    protected override void HandReset()
    {
        if (leap_hand != null)
        {
            Debug.Log("RIGHT IN");
            handIn = true;
            UpdateBrushSize(brushValue);
            if (!erase)
            {
                ChangeColor();
            }
            else
            {
                SetEraser();
            }
        }
    }

    protected override void HandFinish()
    {
        Debug.Log("RIGHT OUT");
        handIn = false;
    }
}
