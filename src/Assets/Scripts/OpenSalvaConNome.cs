using Leap.Unity.Interaction;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OpenSalvaConNome : MonoBehaviour
{
    private InteractionButton button;
    private bool prevPress = false;

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
            string json = File.ReadAllText("Assets/Models/paths.json");
            List<Paths> oldPaths = JsonConvert.DeserializeObject<List<Paths>>(json);
            string extension = oldPaths[oldPaths.Count - 1].path.Substring(oldPaths[oldPaths.Count - 1].path.Length - 3, 3);
            file = new FileManager(oldPaths[oldPaths.Count - 1].path);
            var texture = file.GetTexture();
            if (extension.Equals("png"))
            {
                file.SaveTexturePNG(texture);
            }
            else if (extension.Equals("jpg"))
            {
                file.SaveTextureJPG(texture);
            }
        }
    }
}
