using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelConverter : MonoBehaviour
{
    public static float UnityToPixels(int unityValue)
    {
        return (float)unityValue / 100;
    }
}
