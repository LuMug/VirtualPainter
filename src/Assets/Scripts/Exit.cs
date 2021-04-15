using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Exit : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress = false;

    public GameObject exitUI;

    public GameObject hands;

    private FileManager file;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<InteractionButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed && !prevPress)
        {
            exitUI.SetActive(true);
            hands.SetActive(false);
        }
    }
}
