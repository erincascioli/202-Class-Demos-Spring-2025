using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------------------------------------------------------------------------
// MoveController script - demonstrates how scripts utilize GameObject references.
// Controls Y-axis movement of 3 GameObjects in the scene.  
// ------------------------------------------------------------------------


/// <summary>
/// Demonstrates how scripts utilize GameObject references.
/// Controls Y-axis movement of 3 GameObjects in the scene. 
/// </summary>
public class MoveController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // To modify the Transform component of several GameObjects in the scene,
    //   this script needs a reference to each GameObject. 
    // These references are assigned in the Inspector:
    // ------------------------------------------------------------------------
    public GameObject myCube;
    public GameObject myBall;



    void Start()
    {
        // ------------------------------------------------------------------------
        // References can also be assigned via code.
        // This is usually done when any references aren't able to be set in the Inspector...
        // Like when an object is instantiated via code. In that case, it won't exist in
        //   the scene and be available to drag-and-drop in the Inspector.
        //   It will only appear in the hierarchy *after* the game starts.
        // ------------------------------------------------------------------------
        //myCube = GameObject.Find("Cube");
        //myBall = GameObject.Find("Ball");
    }


    void Update()
    {
        // ------------------------------------------------------------------------
        // Move each of these GameObjects along their Y axis every frame!
        // Changing a referenced position requires modifying a struct.
        // Must copy-alter-replace!
        // ------------------------------------------------------------------------

        // CUBE:
        // 1. Make a copy of the Transform's position
        Vector3 positionCopy = myCube.transform.position;
        // 2. Modify the copy's Y value
        positionCopy.y += 0.005f;
        // 3. Reset the position with this copy.
        myCube.transform.position = positionCopy;

        // BALL:
        positionCopy = myBall.transform.position;
        positionCopy.y += 0.005f;
        myBall.transform.position = positionCopy;
    }
}
