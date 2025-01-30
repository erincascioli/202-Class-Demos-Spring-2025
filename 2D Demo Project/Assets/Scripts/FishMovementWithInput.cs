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

/// <summary>
/// Locomotes a fish using WASD keys.
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

    // TESTING continual rotation of the Jellyfish sprite
    /*
    public float zRotation;
    public float zDelta;
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // --------------------------------------------------------------------
        // Once per frame, call another method in this script!
        // --------------------------------------------------------------------

        // Start by moving fish independently on X or Y axis using per-frame movement.
        MoveFish();

        // --------------------------------------------------------------------
        // TESTING continual rotation of the Jellyfish sprite
        // --------------------------------------------------------------------
        /*
        // Every frame, add a small amount to the angle of rotation.
        zRotation += zDelta;

        // Set the fish's rotation
        fish.transform.rotation = Quaternion.Euler(0, 0, zRotation);

        // Reset the zRotation to 0 when it exceeds 360, keeping all rotations
        //   about the Z axis within a 0 - 360 range.
        if(zRotation >= 360)
        {
            zRotation = 0;
        }
        */
    }

    /// <summary>
    /// Use Unity's Input Manager system to move the fish in 4 cardinal directions
    ///    with WASD.
    /// </summary>
    public void MoveFish()
    {
        // --------------------------------------------------------------------
        // Grab the fish's current position as a locally-declared struct
        // such that it is modifiable.
        // --------------------------------------------------------------------

        Vector3 fishPosition = fish.transform.position;

        // --------------------------------------------------------------------
        // Calculate the jellyfish's position and rotation based on keyboard input!
        // --------------------------------------------------------------------

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

        // --------------------------------------------------------------------
        // Set the fish's transform position to the calculated position
        // This "transports" the fish to that position
        // --------------------------------------------------------------------

        fish.transform.position = fishPosition;        
    }
}
