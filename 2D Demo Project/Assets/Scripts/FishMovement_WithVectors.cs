using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

// ----------------------------------------------------------------------------
// Demo that shows how to use the Input Package system for WASD movement.
// See https://docs.google.com/presentation/d/1qjUHUia0HL6y2n15do41_MG-yAdWPcgmtebj7KM-o6M/edit?usp=sharing
//   for slides on how to set up up/down/left/right composite bindings
//   in the Input Actions asset.
//
// This component is on the Jellyfish Manager empty GO.
// References the fish to locomote.
// ----------------------------------------------------------------------------


/// <summary>
/// FishMovement_WithVectors
/// Captures player's WASD input and transports a fish accordingly.
/// </summary>
public class FishMovement_WithVectors : MonoBehaviour
{
    /// <summary>
    /// Reference to a GameObject to locomote
    /// </summary>
    public GameObject fish;

    /// <summary>
    /// Direction for movement
    /// </summary>
    public Vector2 fishDirection;

    /// <summary>
    /// Calculated as the change in position
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// Number of units to move per frame
    /// </summary>
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Transport the fish to a new location.
        MoveFish();
    }

    
    public void MoveFish()
    {
        // --------------------------------------------------------------------
        // Note: We are NOT using the Rigidbody here to move the fish.
        // Simply transporting the fish to different positions within the window.
        // --------------------------------------------------------------------

        // 1. Calculate the direction - Completed in the GetDirection method!  
        //    - This is done for us with the Input Package system's GetDirection method.
        //    - The direction is a 2D vector.

        // 2. Calculate a velocity --> direction * speed
        //    - Velocity is direction * speed
        velocity = fishDirection * speed;

        // 3. Calculate a new position --> velocity added to position
        //    - Set the fish's position to that vector
        fish.transform.position += velocity;
    }


    /// <summary>
    /// Retrieves Up/Down/Left/Right input from the keyboard
    /// to initialize a direction vector.
    /// </summary>
    /// <param name="context"></param>
    public void GetDirection(InputAction.CallbackContext context)
    {
        // --------------------------------------------------------------------
        // Get input values from WASD: 
        // W returns vector (0, 1) 
        // A returns vector (-1, 0)
        // S returns vector (0, -1)
        // D returns vector (1, 0)
        // Not pressing any WASD keys? Returned vector (0, 0)
        // Combinations of the WASD keys returns an appropriate normalized
        //   vector representing movement along the X and Y axes. 
        // --------------------------------------------------------------------
        fishDirection = context.ReadValue<Vector2>();

        // ***** For Testing! Can be commented out or removed! *****
        // Testing: Inspect the values that are being returned by ReadValue.
        Debug.Log("The direction is " + fishDirection);
    }
    
}
