using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Vehicle : MonoBehaviour
{
    // Reference to Rigidbody on this GameObject
    // NOTE: We still call methods on the Rigidbody even though 
    //   it's not using the physics system’s auto-applied physics.
    public Rigidbody rigidbodyComponent;

    // Part of “movement formula” we've studied thus far
    [SerializeField]
    private Vector3 velocity;
    private Vector3 acceleration;

    // Capturing user input to move vehicle along its forward transform
    [SerializeField]
    private Vector3 movementDirection;

    // Handling smallest and largest speeds
    public float maxSpeed;
    public float minSpeed;

    // Rates of acceleration and deceleration
    public float accelerationRate;
    public float decelerationRate;

    // Steering the vehicle 
    public float turnSpeed;             // scalar of velocity
    public Quaternion turning;		    // rotation

    // Positioning on terrain
    public TerrainData terrainData;     // Set in inspector

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        PositionVehicleAtTerrainHeight();

        //Move1();
        //Move2();
    }

    public void Move1()
    {
        // Remove momentum from acceleration
        acceleration = Vector3.zero;

        // Orient the model so its pointing toward the direction vector
        transform.forward = movementDirection.normalized;

        // Velocity == speed * direction
        // Calculate the velocity at maximum speed (FOR NOW!)
        //velocity = maxSpeed * movementDirection;

        // Handle acceleration
        acceleration = accelerationRate * movementDirection.normalized * Time.fixedDeltaTime;

        // Add acceleration to velocity
        velocity += acceleration;

        // Limit how fast the vehicle moves!
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // How to affect position?
        rigidbodyComponent.MovePosition(transform.position + velocity);
    }

    public void Move2()
    {
        // Use Input to calc current speed for this frame
        float currentSpeed = movementDirection.z * maxSpeed;

        // Fields for Quaternions
        //velocity = transform.forward * currentSpeed;

        // Handle acceleration:
        if (movementDirection.z != 0)
        {
            // Reset acceleration
            acceleration = Vector3.zero;

            // Use Input to calc current acceleration for this frame
            acceleration = transform.forward *
                (movementDirection.z * accelerationRate);

            // Add acceleration to velocity
            velocity += acceleration * Time.deltaTime;

            // Clamp velocity
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }

        //  Handle deceleration:  Slow down while no input
        else if (velocity.magnitude != 0f)
        {
            //	Remove a percentage of the velocity based on time
            velocity *= 1f - (decelerationRate * Time.deltaTime);

            //  Stop the vehicle when it reaches a certain speed
            if (velocity.magnitude < minSpeed)
            {
                velocity = Vector3.zero;
            }
        }

        //  Calc current turning:
        // Rotates around the X axis
        turning = Quaternion.Euler(0f,
            movementDirection.x * turnSpeed * Time.fixedDeltaTime, 0f);

        //  Calc current turning
        Quaternion nextRotation = transform.rotation * turning;

        //  Turn the Vehicle's velocity
        velocity = turning * velocity;

        //  Use velocity to calc next position
        Vector3 nextPosition = transform.position +
            (velocity * Time.fixedDeltaTime);

        //  Move and rotate the Vehicle
        rigidbodyComponent.Move(nextPosition, nextRotation);
    }

    /// <summary>
    /// Positions a vehicle at the terrain's height
    /// </summary>
    public void PositionVehicleAtTerrainHeight()
    {
        // ********************************************************************
        // Option 1: Get the terrain height at an (X, Z) position
        // ********************************************************************
        /*
        // Ask for the height of a terrain at the vehicle's position
        float terrainHeight = 
        terrainData.GetHeight((int)transform.position.x, (int)transform.position.z);

        // Move the vehicle to a position on the terrain
        transform.position = new Vector3(
            transform.position.x,
            terrainHeight,
            transform.position.z);

        // Let's see what the value is:
        Debug.Log("Value at (100, 100) is " + terrainHeight);
        */


        // ********************************************************************
        // Optoin 2: Get the terrain height using raycast
        // ********************************************************************
        RaycastHit raycastData; 

        // Find a position 200 units directly above the vehicle
        Vector3 aboveVehicle = new Vector3(
            transform.position.x,
            200,
            transform.position.z);

        // Send a ray "down" into the terrain
        Physics.Raycast(aboveVehicle, Vector3.down, out raycastData, 200);

        // Let's see what the value is:
        Debug.Log("Value at (100, 100) is " + raycastData.point);

        // Move the vehicle to a position on the terrain
        transform.position = new Vector3(
            transform.position.x,
            raycastData.point.y,
            transform.position.z);

        // Blue line from vehicle center to the end of its forward endpoint
        //   used for debugging!
        Debug.DrawLine(
            transform.position,                                 // Vehicle's center
            transform.position + (transform.right * 5),         // 5 units to the right 
            Color.blue);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection.x = context.ReadValue<Vector2>().x;
        movementDirection.z = context.ReadValue<Vector2>().y;
    }
}
