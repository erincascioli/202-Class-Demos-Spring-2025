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
// References the fish to locomote on a speed per second.
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
    /// Reference to the SpriteRenderer of the jellyfish sprite.
    /// Used to change the tint every # seconds.
    /// </summary>
    public SpriteRenderer fishSprite;

    /// <summary>
    /// Direction for movement.
    /// Derived from the new Input package system.
    /// </summary>
    public Vector2 fishDirection;

    /// <summary>
    /// Calculated as the change in position
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// Number of units to move per second
    /// </summary>
    public float speedPerSecond;

    /// <summary>
    /// Timer of elapsed time; number of seconds that have passed.
    /// </summary>
    public float timer;

    /// <summary>
    /// How often to reset the timer.
    /// </summary>
    public float timerInterval;


    void Start()
    {
        
    }

    void Update()
    {
        // Transport the fish to a new location.
        MoveFish();

        // Is it time to change the jellyfish sprite's color tint?
        ChangeJellyFishColor();
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

        // --------------------------------------------------------------------
        // Movement is now framerate independent using delta time!!!
        // --------------------------------------------------------------------
        // 2. Calculate a velocity --> direction * speed * time
        //    - Multiplying by delta time sets the movement to be frame-rate independent
        //      by focusing on movement per second.
        velocity = (fishDirection * speedPerSecond) * Time.deltaTime;

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


    /// <summary>
    /// Simple frame count timer.
    /// </summary>
    public void ChangeJellyFishColor()
    {
        // --------------------------------------------------------------------
        // Capture the elapsed time from last frame to this one
        // This will increase every frame, until the value is reset.
        // --------------------------------------------------------------------

        timer += Time.deltaTime;

        // --------------------------------------------------------------------
        // After # seconds have passed, something happens!
        // --------------------------------------------------------------------

        // Once timer has passed the interval
        if (timer >= timerInterval)
        {
            // Reset the timer (include lost time here)
            timer -= timerInterval;

            // Change the color tint of the Jellyfish from its SpriteRenderer component
            fishSprite.color = new Color(
                Random.Range(0, 1f), 
                Random.Range(0, 1f), 
                Random.Range(0, 1f));
        }
    }    
}
