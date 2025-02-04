using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------
// FishMovementWithInput script is used to locomote (move) a sprite in the scene.
// It uses Unity's "old" Input Manager system to capture user input via the
//   keyboard and mouse.
// The sprite currently moves to the left (decreases its position's X value)
//   and rotates to face left (180 degrees) as long as a user presses the A key.
// Students are expected to complete movement for the W, S and D keys before our
//   next class session.
// This script has some code to test continual rotation (i.e. the fish rotates
//   counter-clockwise, resulting in the fish rotating about its center.
//   That code is here but commented out. 
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Progress in class on Tuesday 2/4/25:
//  - Jellyfish no longer moves using the WASD keys.
//  - Jellyfish can be transported to the mouse's location using the 
//    TransportFish() method
//  - Jellyfish can rotate toward the mouse's location using the
//    RotateTowardMouse() method
// ----------------------------------------------------------------------------


/// <summary>
/// Practice with simple key-based input using the Input Manager system to 
/// influence position and/or rotation.
/// </summary>
public class FishMovementWithInput : MonoBehaviour
{
    /// <summary>
    /// Object that this script moves with WASD or arrow keys. Reference set in Inspector.
    /// </summary>
    public GameObject fish;

    /// <summary>
    /// Unit-based movement per second for the fish. Value set in Inspector.
    /// </summary>
    public float speed;

    /// <summary>
    /// Angle of rotation used for pointing the sprite in any direction
    /// </summary>
    public float angleOfRotation;

    // ************
    // NOTE: 1/31/25
    // This code is part of the testing code in the Update method.  These fields are no longer needed.
    // TESTING continual rotation of the Jellyfish sprite
    // ************
    /*
    public float zRotation;
    public float zDelta;
    */


    void Start()
    {
        
    }

    void Update()
    {
        // ----------------------------------------------------------------------------------------
        // The Jellyfish can either transport to the mouse or rotate toward the mouse
        // ----------------------------------------------------------------------------------------
        // Uncomment and/or comment out these methods to see the result in the Unity editor!
        RotateTowardMouse();
        //TransportFish();

        // ************
        // NOTE 2/4/25: Commented out this method. No longer moving the fish with WASD.
        // Start by moving fish independently on X or Y axis using per-frame movement.
        //MoveFish();
        // ************

        // ************
        // NOTE 1/31/25: This code is commented because we were just testing this concept in class.
        // Every frame, add a small amount to the angle of rotation.
        //zRotation += zDelta;

        // Set the fish's rotation
        //fish.transform.rotation = Quaternion.Euler(0, 0, zRotation);

        // Reset the zRotation to 0 when it exceeds 360, keeping all rotations
        //   about the Z axis within a 0 - 360 range.
        //if(zRotation >= 360)
        //{
        //    zRotation = 0;
        //}
        // ************
    }

    /// <summary>
    /// Use Unity's Input Manager system to move the fish in 4 cardinal directions
    ///    with WASD.
    /// </summary>
    public void MoveFish()
    {
        // ----------------------------------------------------------------------------------------
        // Grab the fish's current position as a locally-declared struct
        // such that it is modifiable.
        // ----------------------------------------------------------------------------------------

        Vector3 fishPosition = fish.transform.position;

        // ----------------------------------------------------------------------------------------
        // Calculate the jellyfish's position and rotation based on keyboard input!
        // ----------------------------------------------------------------------------------------

        // When the A key is pressed, move fish to the left
        if (Input.GetKey(KeyCode.A))				// Left/A key
        {
            // Prove to ourselves that the key presses are working!
            UnityEngine.Debug.Log("Pressing A");

            // Move the object a tiny unit left
            fishPosition.x -= speed;

            // Rotate the fish so it points in the correct direction. 
            // Leftward movement --> 180 rotation around the Z axis.
            fish.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        // ** COMPLETE THESE IF STATEMENTS WITH THE W, S AND D KEYS!!! **
        // ** THEN COMPLETE THE IF STATEMENT BODIES BEFORE NEXT CLASS! **
        /*
        else if ()                       // Right/D key
        {
            // How to move the fish? 
        }
        else if ()                       // Up/W key
        {
            // How to move the fish?
        }
        else if ()                       // Down/S key
        {
            // How to move the fish?
        }
        */

        // ----------------------------------------------------------------------------------------
        // Set the fish's transform position to the calculated position
        // This "transports" the fish to that position
        // ----------------------------------------------------------------------------------------

        fish.transform.position = fishPosition;        
    }


    /// <summary>
    /// Sets the Jellyfish's position to the mouse position.
    /// </summary>
    public void TransportFish()
    {
        // Set this fish's position at the mouse position!
        // Translate between screen space and world space.
        Vector3 worldLocationOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Zero out the Z component so that the layering (or a normalized vector) isn't affected
        //   by a vector with a seemingly random Z position.
        worldLocationOfMouse.z = 0;

        // Set the fish's position to the mouse's position in world space
        fish.transform.position = worldLocationOfMouse;
    }


    /// <summary>
    /// Rotates the Jellyfish so its head points toward the mouse position.
    /// </summary>
    public void RotateTowardMouse()
    {
        // Retrieve the mouse position in world space
        Vector3 worldLocationOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Since the fish may not be positioned at the center of the world (origin 0, 0, 0), 
        //   must get a vector that represents desired rotation.
        Vector3 localLookVector = worldLocationOfMouse - fish.transform.position;

        // Then use Atan2 to calculate the angle of rotation (in degrees!)
        angleOfRotation = Mathf.Atan2(localLookVector.y, localLookVector.x) * Mathf.Rad2Deg;

        // Set the rotation around the Z axis
        fish.transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
    }
}
