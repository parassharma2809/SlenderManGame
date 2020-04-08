using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for loop which gets keycode vkey
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            //When the key is pressed
            if (Input.GetKeyDown(vKey))
            {
                Debug.Log(vKey + " is pressed " + System.DateTime.Now.ToString("HH:mm:ss"));
            }
            if (Input.GetKeyUp(vKey))
            {
                Debug.Log(vKey + " is released " + System.DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
}
