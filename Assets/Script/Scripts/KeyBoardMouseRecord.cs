using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardMouseRecord : MonoBehaviour
{
    public Vector2 mouseSpeed = Vector2.zero;
    public Vector2 mousePosition = Vector2.zero;
    private string TAG1 = "MouseSpeed:";
    private string TAG2 = "KeyStroke:";
    private string TAG3 = "MouseCoord:";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ScreenSize:" + Screen.currentResolution);
    }

    // Update is called once per frame
    //Attach this script to the Game object which runs at the start of the game (Eg: First Player Controller)
    void Update()
    {
        recordMouseMovementVelocity();  // Record the mouse velocity every frame
        recordMousePosition();  // Record the mouse coordinates every frame
        recordKeyStroke();  // Record the Key pressed and released every frame
    }

    void recordMouseMovementVelocity()
    {
        mouseSpeed.x = Input.GetAxis("Mouse X");
        mouseSpeed.y = Input.GetAxis("Mouse Y");
        Debug.Log(TAG1 + System.DateTime.Now.ToString("HH:mm:ss") + " Speed " + mouseSpeed.magnitude);
    }

    void recordMousePosition()
    {
        mousePosition.x = Input.mousePosition.x;
        mousePosition.y = Input.mousePosition.y;
        Debug.Log(TAG3 + System.DateTime.Now.ToString("HH:mm:ss") + " " + mousePosition);
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
