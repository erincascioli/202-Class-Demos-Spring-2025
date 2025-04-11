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

    // Speed for movement
    public float maxSpeed;

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

        // Basic "movement" for agents
        acceleration += steeringForce;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    // ADD ALL STEERING METHODS HERE!
    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 seekingForce = Vector3.zero;

        // Calculate a desired velocity (point toward the target)
        Vector3 desiredVelocity = targetPosition - velocity;

        // Scale to maximum speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate the seeking force needed
        seekingForce = desiredVelocity - velocity;

        return seekingForce;
    }

    // Overloaded Seek
    public Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }


}
