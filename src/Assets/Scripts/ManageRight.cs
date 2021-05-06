using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Zeno Darani, Sara Bressan, Karim Galliciotti, Stefano Mureddu

/// <summary>
/// La classe <c>Manage Right</c> serve a gestire le azioni eseguite dalla mano destra,
/// in pratica legge il Leap Motion capta i movimenti della mano destra e questo script
/// interpreta i movimenti.
/// </summary>
public class ManageRight : HandTransitionBehavior
{
    /// <summary>
    /// La dimensione massima del pennello
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
    /// Il contenitore/modello delle mani.
    /// </summary>
    HandModel hand_model;

    /// <summary>
    /// La mano destra inserita/visibile.
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
    /// Il colore attuale della penna.
    /// </summary>
    Color color = new Color(0,0,0);

    /// <summary>
    /// Oggetto per la gestione degli script del programma.
    /// </summary>
    public GameObject actionController;

    /// <summary>
    /// La mano sinistra inserita.
    /// </summary>
    public GameObject leftHand;

    /// <summary>
    /// Piano su cui si applica a tela/texture.
    /// </summary>
    public GameObject tela;

    /// <summary>
    /// Mostra se in precedenza l'indice e il pollice della mano si toccavano.
    /// </summary>
    bool prevPinch = false;

    /// <summary>
    /// Indica se l'indice e il pollice della mano sono vicini.
    /// </summary>
    private bool pinch;

    /// <summary>
    /// Indica se la mano è stretta a pugno.
    /// </summary>
    private bool grab;

    /// <summary>
    /// Indica se è attivo lo strumento gomma.
    /// </summary>
    private bool erase;

    /// <summary>
    /// Corrisponde alla distanza tra indice e pollice della mano.
    /// </summary>
    private float pinchDistance;

    /// <summary>
    /// Corriponde alla posizione normalizzata della mano (posizione della mano)
    /// </summary>
    private Vector palmNormal;

    /// <summary>
    /// Indica se la/una mano destra è rilevata dal LeapMotion Controller.
    /// </summary>
    private bool handIn;

    /// <summary>
    /// Corrsiponde alla grandezza del pannello tra 0 e 1.
    /// </summary>
    private float brushValue;

    /// <summary>
    /// Start viene eseguito una volta quando parte lo script.
    /// </summary>
    void Start()
    {
        // Prende il componente RigidHand presente in questo oggetto (Mano destra).
        hand_model = this.GetComponent<RigidHand>();
        // Seleziona la mano presente nel modello hand_model (Mano destra).
        leap_hand = hand_model.GetLeapHand();
        // Se la mano non viene rilevata solleva un errore.
        if (leap_hand == null) Debug.LogError("No leap_hand founded");

        // assegna l'azione UpdateBrushSize all'evento di movimento dello slider
        BrushSizeSlider.HorizontalSlideEvent = new Action<float>(UpdateBrushSize);

        // Debugging code
        // Assegnazione della texture.
        Texture2D tt = (Texture2D)tela.GetComponent<Renderer>().material.mainTexture;
        //DrawCircle(tt,Color.black, 0, 0, 10);
    }

    /// <summary>
    /// Metodo eseguito ad ogni frame.
    /// </summary>
    void Update()
    {
        // Seleziona la mano destra presente nel frame attuale.
        leap_hand = hand_model.GetLeapHand();
        // Se non viene trovata nessuna mano crea un errore.
        if (leap_hand == null) Debug.LogError("No leap_hand founded");

        try
        {
            // Se la mano destra è presente.
            if (handIn)
            {
                // Salva la posizione normalizzata della mano.
                palmNormal = leap_hand.PalmPosition;

                // Se il pollice e l'indice si avvicinano.
                if (leap_hand.IsPinching())
                {
                    // Imposta la mano come "pinchante"
                    pinch = true;
                    // Salva la distanza tra pollice e indice.
                    pinchDistance = leap_hand.PinchDistance;

                    // Disegna
                    Draw();
                    //fill();
                }
                // Se la mano non fa pinch.
                else
                {
                    // Indica che l'indice e il pollice non sono vicini.
                    pinch = false;
                    // Indica che l'indice e il pollice non sono più vicini.
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

                // Se la mano è stretta a pugno
                if (leap_hand.GrabStrength == 1)
                {
                    // Indica che la mano è stretta a pugno.
                    grab = true;
                }
                else
                {
                    // Indica che la mano non è stretta a pugno.
                    grab = false;
                }

            }
        }
        // Se la mano non è inserita
        catch (NullReferenceException e)
        {
            // Crea un errore.
            Debug.LogError("Mani non inserite " + e.Message);
        }
    }

    /// <summary>
    /// Ritorna se la mano è pinchata (indice e pollice sono vicini)
    /// </summary>
    /// <returns>lo stato di pinching della mano</returns>
    public bool IsHandPinching()
    {
        // Ritorna se il pollice e l'indice della mano sono molto vicini o si toccano.
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
    /// Ritorna la distanza tra indice e pollice della mano.
    /// </summary>
    /// <returns>la distanza tra indice e pollice della mano</returns>
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
            // applica il disegno sulla tela
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
    /// <returns>la texture</returns>
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
        // Imposta la gomma come attiva.
        erase = true;
        // Il colore del pennello è ora bianco così da "cancellare" gli altri colori.
        color = Color.white;
    }
    
    /// <summary>
    /// Imposta la penna come strumento attivo.
    /// </summary>
    public void SetPen()
    {
        // Disattiva la gomma.
        erase = false;
        // Reimposta il colore che era attivo prima di selezionare lo strumento gomma.
        ChangeColor();
    }

    /// <summary>
    /// Ritrona lo stato della gomma (attivo/disattivo)
    /// </summary>
    /// <returns>lo stato della gomma</returns>
    public bool GetEraser()
    {
        return erase;
    }

    /// <summary>
    /// Effettua l'azione di riempimento.
    /// L'azione riempimento è disattivata in quanto non funzionante.
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
    /// Algoritmo utile per il riempimento.
    /// Funzione non utilizzata momentaneamente in quanto rallentava eccessivamente il programma.
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
    /// Controlla se il pixel seguente è da colorare oppure no.
    /// Funzione utilizzata dal filler e quindi non più utilizzata.
    /// </summary>
    /// <param name="texture">la texture</param>
    /// <param name="width">la larghezza della texture</param>
    /// <param name="height">l'altezza della texture</param>
    /// <param name="p">il punto </param>
    /// <param name="sourceColor">colore in cui trasformare i pixel</param>
    /// <param name="tollerance">valore di tolleranza</param>
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

    /// <summary>
	/// Metodo che viene richiamato quando la mano sinistra viene captata dal Leap Motion.
	/// </summary>
    protected override void HandReset()
    {
        // Se la mano è veramente inserita
        if (leap_hand != null)
        {
            // Notifica che la mano destra è inserita.
            Debug.Log("RIGHT IN");
            // Imposta la mano destra come inserita.
            handIn = true;
            // Imposta l'attuale grandezza della penna come l'ultima utilizzata.
            UpdateBrushSize(brushValue);
            // Se la gomma è disattivata
            if (!erase)
            {
                // Imposta il colore della penna come l'ultimo utilizzato.
                ChangeColor();
            }
            else
            {
                // Attiva la gomma
                SetEraser();
            }
        }
        else
        {
            // Imposta la mano come non inserita
            handIn = false;
        }
    }

    /// <summary>
	/// Metodo che viene richiamato quando il Leap Motion termina di captare la mano, 
	/// se la mano prima era inserita e ora non lo è più.
	/// </summary>
    protected override void HandFinish()
    {
        // Notifica l'uscita della mano dal programma.
        Debug.Log("RIGHT OUT");
        // Imposta la mano come non inserita.
        handIn = false;
    }
}
