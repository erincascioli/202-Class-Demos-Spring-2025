using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------------------------------------------
// Collision Destroy
// Used to demonstrate how a script can destroy another GameObject.
// In this script, when a game object (let's call it object A) collides with the
//   game object that this script is on (let's call it object B), the other
//   game object (A) is destroyed. 
// No need to declare a reference to the other game object (A) as a field
//   of the class... the OnCollisionEnter2D method contains a parameter
//   "collision" which is a reference to information about the exact collision
//   that happened - including a reference to the other game object (A) that
//   collided with this game object (B)!
// ----------------------------------------------------------------------------

/// <summary>
/// Removes a game object that collided with the game object this script is on.
/// </summary>
public class CollisionDestroy : MonoBehaviour
{
    #region Unused methods
    // Start is called before the first frame update
    void Start()
    {
        // Nothing in here! Feel free to delete the Start method if desired!
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing in here! Feel free to delete the Update method if desired!
    }
    #endregion

    /// <summary>
    /// Handles a collision with this GameObject.
    /// </summary>
    /// <param name="collision">Reference information about the collision that occurred.</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // ------------------------------------------------------------------------------
        // The parameter "collision" also has cool stuff that you can use, like:
        // - How many objects collided with this one 
        // - the game object that collided (as used in the Destroy method above)
        // - the other object's collider and Rigidbody
        // - the other object's transform
        // - and more!
        // Visit https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Collision2D.html
        //   to find out more!
        // ------------------------------------------------------------------------------

        // Remove the colliding game object from the hierarchy.
        Destroy(collision.gameObject);
    }
}
