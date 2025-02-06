using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MessageSender : MonoBehaviour
{
    public string messageToSend;        // Value is set in Inspector

    void Start()
    {
        
    }
    void Update()
    {
        
    }


    // This method will "fire" (be invoked) when the left mouse button
    //   or the W key is pressed.
    public void FireMessage(InputAction.CallbackContext context)
    {
        // As long as the left mouse button has been fully clicked,
        //   or the W key has been pressed and released,
        //   print a message to the Console window
        if(context.performed)
        {
            Debug.Log(messageToSend);
        }
    }
}
