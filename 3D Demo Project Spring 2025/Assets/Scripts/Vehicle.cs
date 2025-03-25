using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Vehicle : MonoBehaviour
{
    // Reference to Rigidbody on this GameObject
    // NOTE: We still call methods on the Rigidbody even though 
    //   it's not using the physics system’s auto-applied physics.
    public Rigidbody rigidbody;

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
    public float turnSpeed;         // scalar of velocity
    private Quaternion turning;		// rotation

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        //Move1();
        Move2();
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
        rigidbody.MovePosition(transform.position + velocity);
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

        // Scale the Velocity to be based on Time not Frame rate
        Vector3 delta = velocity * Time.fixedDeltaTime;

        // Move the Vehicle
        rigidbody.MovePosition(transform.position + delta);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection.x = context.ReadValue<Vector2>().x;
        movementDirection.z = context.ReadValue<Vector2>().y;
    }
}
