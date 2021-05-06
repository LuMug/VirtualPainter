using Leap;
using Leap.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Sara Bressan

/// <summary>
/// La classe <c>Manage Left</c> serve a gestire le azioni eseguite dalla mano sinistra,
/// in pratica legge il Leap Motion capta i movimenti della mano sinistra e questo script
/// interpreta i movimenti.
/// </summary>
public class ManageLeft : HandTransitionBehavior
{
	/// <summary>
	/// Il contenitore/modello delle mani.
	/// </summary>
	HandModel hand_model;

	/// <summary>
	/// La mano sinistra inserita/visibile.
	/// </summary>
	Hand leap_hand;

	/// <summary>
	/// Il controller delle mani.
	/// </summary>
	Controller controller = new Controller();

	/// <summary>
	/// Corrisponde al pannello di bottoni dell'inventario (quello che appare ruotando la mano sinistra).
	/// </summary>
	public GameObject menu;

	/// <summary>
	/// Il modello di mano che utilizziamo.
	/// </summary>
	public GameObject rightHand;

	/// <summary>
	/// Corrisponde all'oggetto che gestisce i vari script del programma.
	/// </summary>
	public GameObject actionController;

	/// <summary>
	/// Indica se la mano è stretta a pugno.
	/// </summary>
	private bool isGrabbing;

	/// <summary>
	/// Indica se il palmo della mano è ruotato verso l'alto.
	/// </summary>
	private bool isFaceUp;

	/// <summary>
	/// Indica se il pollice e l'indice della mano si toccano.
	/// </summary>
	private bool isPinching;

	/// <summary>
	/// Indica se la mano è captata dal Leap Motion.
	/// </summary>
	private bool handIn;

	/// <summary>
	/// Start viene eseguito una volta quando parte lo script (al primo frame).
	/// </summary>
	void Start()
	{
		// Prende il componente mano dal contenitore delle mani.
		hand_model = this.GetComponent<RigidHand>();
		// Prende la mano inserita.
		leap_hand = hand_model.GetLeapHand();
		// Se non è presente nessuna mano solleva un errore.
		if (leap_hand == null) Debug.LogError("No leap_hand founded");

	}

	/// <summary>
	/// Metodo eseguito ad ogni frame.
	/// </summary>
	void Update()
	{
		// Ad ogni frame cerca la mano sinistra inserita.
		leap_hand = hand_model.GetLeapHand();
		// Se non è presente nessuna mano solleva un errore.
		if (leap_hand == null) Debug.LogError("No leap_hand founded");

		try
		{
			// Se la mano sinistra è inserita
			if (handIn)
			{
				// Se la mano è stretta a pugno
				if (leap_hand.GrabStrength == 1)
				{
					// Salva lo stato della mano stretta a pugno.
					isGrabbing = true;
				}
				// altrimenti
				else
				{
					// Salva lo stato della mano che non è distesa.
					isGrabbing = false;
				}

				// Se l'indice della mano e il pollice della mano sono vicini o si toccano
				if (leap_hand.IsPinching())
				{
					// Salva lo stato di pinching.
					isPinching = true;
				}
				// altrimenti
				else
				{
					// Salva lo stato di pinching.
					isPinching = false;
				}

				// Se il palmo della mano è rivolto verso l'alto
				if (leap_hand.PalmNormal.y >= 0)
				{
					// Mostra il menù inventario.
					menu.SetActive(true);
					// Salva lo stato del palmo.
					isFaceUp = true;
				}
				// altrimenti
				else
				{
					// Disattiva il menì inventario.
					menu.SetActive(false);
					// Salva lo stato del palmo.
					isFaceUp = false;
				}

				// Gestione dello zoom che è stata disattivata.
				//if (isPinching && rightHand.GetComponent<ManageRight>().IsHandPinching())
				//{
				//	double distance = leap_hand.PalmPosition.DistanceTo(rightHand.GetComponent<ManageRight>().GetPalmNormal());
				//	if (distance > 0.38)
				//	{
				//		actionController.GetComponent<Zoom>().ZoomOut();
				//	}
				//	else if (distance < 0.2)
				//	{
				//		actionController.GetComponent<Zoom>().ZoomIn();
				//	}
				//}

				// Se entrambe le mani sono strette a pugno
				if (isGrabbing && rightHand.GetComponent<ManageRight>().IsHandGrabbing())
				{
					// Notifica lo stato delle mani.
					Debug.Log("Both hand grab");
				}
            }
		}
		// Se nessuna mano è inserita
		catch (NullReferenceException e)
		{
			// Notifica l'assenza di mani
			Debug.LogError("Mani non inserite " + e.Message);
			// Disattiva il menu inventario attaccato alla mano sinistra.
			menu.SetActive(false);
		}
	}

	/// <summary>
	/// Ritorna se la mano è totalmente chiusa (pugno)
	/// </summary>
	/// <returns>ritorna lo stato di grab della mano</returns>
	public bool IsGrabbing()
	{
		return isGrabbing;
	}

	/// <summary>
	/// Ritorna se la mano è girata
	/// </summary>
	/// <returns>ritorna se la mano è girata</returns>
	public bool IsFaceUp()
	{
		return isFaceUp;
	}

	/// <summary>
	/// Ritorna se la mano è pinchata (indice e pollice sono vicini)
	/// </summary>
	/// <returns>lo stato di pinching della mano</returns>
	public bool IsPinching()
	{
		return isPinching;
	}

	/// <summary>
	/// Metodo che viene richiamato quando la mano sinistra viene captata dal Leap Motion.
	/// </summary>
    protected override void HandReset()
    {
		// Notifica che la mano sinistra è inserita
		Debug.Log("LEFT IN");
		// Se la mano è veramente inserita
		if (leap_hand != null)
		{
			// Indica che la mano è captata dal Leap Motion.
			handIn = true;
			// Se la mano ha il palmo verso l'alto
			if (leap_hand.PalmNormal.y >= 0)
			{
				// Mostra il menù inventario.
				menu.SetActive(true);
				// Indica che la mano è girata.
				isFaceUp = true;
			}
			// altrimenti
			else
			{
				// Nasconde il menù inventario.
				menu.SetActive(false);
				// Indica che la mano non è girata.
				isFaceUp = false;
			}
        }
		// altrimenti
        else
		{
			// Indica che la mano non è inserita.
			handIn = false;
		}
	}

	/// <summary>
	/// Metodo che viene richiamato quando il Leap Motion termina di captare la mano, 
	/// se la mano prima era inserita e ora non lo è più.
	/// </summary>
    protected override void HandFinish()
    {
		// Indica che la mano è uscita dal programma.
		Debug.Log("LEFT EXIT");
		// Indica che la mano non è più inserita.
		handIn = false;
		// Disattiva il menù inventario.
		menu.SetActive(false);
    }
}
