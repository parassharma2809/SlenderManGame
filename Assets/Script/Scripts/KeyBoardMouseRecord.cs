using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardMouseRecord : MonoBehaviour
{
    public Vector2 mouseSpeed = Vector2.zero;
    private string TAG1 = "MouseSpeed:";
    private string TAG2 = "KeyStroke:";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Attach this script to the Game object which runs at the start of the game (Eg: First Player Controller)
    void Update()
    {
        recordMouseMovementVelocity();  // Record the mouse velocity every frame

        recordKeyStroke();  // Record the Key pressed and released every frame
    }

    void recordMouseMovementVelocity()
    {
        mouseSpeed.x = Input.GetAxis("Mouse X");
        mouseSpeed.y = Input.GetAxis("Mouse Y");
        Debug.Log(TAG1 + System.DateTime.Now.ToString("HH:mm:ss") + " Speed " + mouseSpeed.magnitude);
    }

    void recordKeyStroke()
    {
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(vKey))
            {
                Debug.Log(TAG2 + System.DateTime.Now.ToString("HH:mm:ss") + " " + vKey + " pressed");
            }
            if(Input.GetKeyUp(vKey))
            {
                Debug.Log(TAG2 + System.DateTime.Now.ToString("HH:mm:ss") + " " + vKey + " released");
            }
        }
    }
}
