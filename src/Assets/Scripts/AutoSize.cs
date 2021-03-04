using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSize : MonoBehaviour
{
    public float FixedSizeZ;
    public float FixedSizeX;
    public void AutoSizeTela(Camera mainCamera, GameObject tela, int larghezza, int altezza)
    {
        var distance = (mainCamera.transform.position - tela.transform.position).magnitude;
        FixedSizeZ = altezza / (distance * mainCamera.fieldOfView);
        FixedSizeX = larghezza / (distance * mainCamera.fieldOfView);
        var sizeZ = distance * FixedSizeZ * mainCamera.fieldOfView;
        var sizeX = distance * FixedSizeX * mainCamera.fieldOfView;
        float moltiplicatore = Math.Min((float)1920.0 / larghezza, (float)1080.0 / altezza);
        tela.transform.localScale = new Vector3(sizeX / 100 * moltiplicatore, 0, sizeZ / 100 * moltiplicatore);
    }
}
