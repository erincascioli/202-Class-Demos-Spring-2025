using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{

    // Fields for ALL children
    // Accel & Velocity vectors
    [SerializeField]
    protected Vector3 velocity;

    [SerializeField]
    protected Vector3 acceleration;

    // Maximums for movement
    public float maxSpeed;
    public float maxForce;

    void Start()
    {
        
    }


    public abstract Vector3 CalcSteeringForce();

    protected void Update()
    {
        // Start "fresh" each frame
        acceleration = Vector3.zero;

        // Calculate a steering force
        Vector3 steeringForce = CalcSteeringForce();

        // Limited the steering force to a max
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);

        // Basic "movement" for agents
        acceleration += steeringForce;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    /// <summary>
    /// Calculate a steering force to move an Agent toward a desired position
    /// in the world.
    /// </summary>
    /// <param name="targetPosition">Specified position to seek</param>
    /// <returns>Steering force for seeking</returns>
    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 seekingForce = Vector3.zero;

        // Calculate a desired velocity (point toward the target)
        Vector3 desiredVelocity = targetPosition - transform.position;

        // Scale to maximum speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate the seeking force needed
        seekingForce = desiredVelocity - velocity;

        return seekingForce;
    }

    /// <summary>
    /// Calculate a steering force to move an Agent toward a desired GameObject
    /// in the world.
    /// </summary>
    /// <param name="target">GameObject to seek</param>
    /// <returns>Steering force for seeking</returns>
    public Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }


    /// <summary>
    /// Calculate a steering force to move an Agent away from a desired position
    /// in the world.
    /// </summary>
    /// <param name="targetPosition">Specified position to flee</param>
    /// <returns>Steering force for fleeing</returns>
    public Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 fleeingForce = Vector3.zero;

        // Calculate a desired velocity (point toward the target)
        Vector3 desiredVelocity = transform.position - targetPosition;

        // Scale to maximum speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate the seeking force needed
        fleeingForce = desiredVelocity - velocity;

        return fleeingForce;
    }
}
