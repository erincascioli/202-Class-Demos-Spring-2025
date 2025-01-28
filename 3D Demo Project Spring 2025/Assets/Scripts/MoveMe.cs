using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------------------------------------------------------------------------
// MoveMe script - used for demonstrating how an object's transform position
// can be modified on a per-frame basis. 
// ------------------------------------------------------------------------


/// <summary>
/// Modifies the transform's Y position to "raise" a GameObject in the scene.
/// </summary>
public class MoveMe : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // This field's value is set in the Inspector. Look there for its value.
    // ------------------------------------------------------------------------

    /// <summary>
    /// Rate of increase on the Y axis
    /// </summary>
    public float ySpeed;

    // ------------------------------------------------------------------------
    // If you don't need the Start method, you could leave it or delete it.
    // Your choice!
    // ------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ------------------------------------------------------------------------
        // Once per frame, change the Y value of the transform's position's Y value.
        // ------------------------------------------------------------------------

        // WRONG! An error appears that "this is not a variable"
        //transform.position.y += 0.05;

        // ------------------------------------------------------------------------
        // Keep in mind that Vector3's are structs... And structs cannot be directly modified
        //   as long as they are referenced.
        // How is this referenced you wonder?
        // Well, the position vector is not a field of THIS class.
        // It's returned from the Position property.
        // And a vector returned from a property or a method, or part of an object are NOT local vectors.
        // Referenced structs CAN be modified via the copy-alter-replace process though!
        // ------------------------------------------------------------------------

        // 1. Make a COPY of the position vector.
        Vector3 positionCopy = transform.position;

        // 2. Change the copy's Y component in the desired manner.
        positionCopy.y += ySpeed;

        // Replace the entire position vector with the copy.
        transform.position = positionCopy;

        // OR if desired, this can be done in one initialization step:
        //transform.position = 
        //    new Vector3(transform.position.x, transform.position.y + ySpeed, transform.position.z);
    }
}
