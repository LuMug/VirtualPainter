using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Karim Galliciotti e Stefano Mureddu

/// <summary>
/// La classe <c>AutoSize</c> ha la funzione di scalare le dimensioni del piano della tela in modo da
/// averla sempre il più grande possibile.
/// </summary>
public class AutoSize : MonoBehaviour
{
    /// <summary>
    /// Gestisce la dimensione del piano al quale viene applicata la texture in modo da averla sempre grande quanto la grandezza dello schermo.
    /// </summary>
    /// <param name="mainCamera">la camera principale</param>
    /// <param name="tela">il piano sul quale viene applicata la tela</param>
    /// <param name="larghezza">la larghezza della tela</param>
    /// <param name="altezza">l'altezza della tela</param>
    public void AutoSizeTela(Camera mainCamera, GameObject tela, int larghezza, int altezza)
    {
        // La distanza dalla tela alla camera
        var distance = (mainCamera.transform.position - tela.transform.position).magnitude;
        // Calcola un rapporto fra altezze e largezze della tela e il campo visivo della telecamera
        var FixedSizeZ = altezza / (distance * mainCamera.fieldOfView);
        var FixedSizeX = larghezza / (distance * mainCamera.fieldOfView);
        // Imposta l'altezza e la larghezza della tela
        var sizeZ = distance * FixedSizeZ * mainCamera.fieldOfView;
        var sizeX = distance * FixedSizeX * mainCamera.fieldOfView;
        // Prende il rapporto più piccolo fra altezza e larghezza in formato 16/9
        float moltiplicatore = Math.Min((float)1920.0 / larghezza, (float)1080.0 / altezza);
        // Modifica la scala della tela
        tela.transform.localScale = new Vector3(sizeX / 100 * moltiplicatore, 0, sizeZ / 100 * moltiplicatore);
    }
}
