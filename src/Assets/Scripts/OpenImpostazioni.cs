using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenImpostazioni : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress;
    public GameObject configurazione_tela;
    public GameObject hands;
    public GameObject tela;

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
            configurazione_tela.SetActive(true);
            hands.SetActive(false);
            tela.SetActive(false);
            prevPress = true;
        }
        else if (!button.isPressed && prevPress)
        {
            prevPress = false;
        }
    }
}
