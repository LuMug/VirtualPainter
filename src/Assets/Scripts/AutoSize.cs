using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var distance = (mainCamera.transform.position - tela.transform.position).magnitude;
        var FixedSizeZ = altezza / (distance * mainCamera.fieldOfView);
        var FixedSizeX = larghezza / (distance * mainCamera.fieldOfView);
        var sizeZ = distance * FixedSizeZ * mainCamera.fieldOfView;
        var sizeX = distance * FixedSizeX * mainCamera.fieldOfView;
        float moltiplicatore = Math.Min((float)1920.0 / larghezza, (float)1080.0 / altezza);
        tela.transform.localScale = new Vector3(sizeX / 100 * moltiplicatore, 0, sizeZ / 100 * moltiplicatore);
    }
}
