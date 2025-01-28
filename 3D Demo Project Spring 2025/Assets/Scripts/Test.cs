using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------------------------------------------------------------------------
// Test script - used for testing the Console window and explaining concepts
//   about how scripts work within the Inspector.  
// There is no "higher" or "deeper" meaning to this class. :)  
// Feel free to delete in your own projects!
// ------------------------------------------------------------------------


/// <summary>
/// Used for testing the Console window and interface introduction to students.
/// Can be deleted once students are familiar and comfortable with Unity's interface.
/// </summary>
public class Test : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Fields
    // ------------------------------------------------------------------------
    // Fields can be added to scripts.  
    // Private --> Cannot be accessed by any other class.
    //             Not visible or editable in the Inspector.
    //             Want to see/edit the field? Use [SerializeField] attribute!
    // Public -->  Can be accessed by other classes.
    //             Visible and editable in the Inspector. 
    //             Want to hide the field? Use[HideInInspector] attribute!
    // Field values can be set here, at field declaration. 
    // ------------------------------------------------------------------------

    // Visible in Inspector!
    [SerializeField]
    private int number = 28492;

    // Not visible!
    private string word = "Hiiii";


    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    // Properties can be added to scripts, too.  
    // These are usually public, so outside classes can interact with private
    //    fields in a class.
    // ------------------------------------------------------------------------


    // ------------------------------------------------------------------------
    // Constructors (NO!)
    // ------------------------------------------------------------------------
    // Do NOT add a constructor to your scripts!  Unity handles constructors
    //    behind-the-scenes.
    // ------------------------------------------------------------------------


    // ------------------------------------------------------------------------
    // Methods
    // ------------------------------------------------------------------------
    // Each script comes with the Start() and Update() methods.
    // Use the Start method like you would a constructor:
    //   - initialize values, if needed
    //   - other setup for your class
    // The Update() method will execute once per frame.  Use this for continual
    //   progress in your project, like:
    //   - moving characters or other objects
    //   - keeping track of values
    //   - determining what should occur next (i.e. has the player's score
    //     increased by 100? advance to the next level!)
    //   - ... and anything else that needs to occur throughout the gameplay!
    // ------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        // ------------------------------------------------------------------------
        // Any field values initialized here will overwrite the value visible in the Inspector.
        // And they will overwrite any values initialized upon declaration, like the values
        //   28942 and "Hiiii" that I set when I declared the number and word fields.
        // ------------------------------------------------------------------------
        number = 2;
        word = "whatever";

        // ------------------------------------------------------------------------
        // Here I'm playing with the Debug.Log method, which sends a message to the Console window.
        // This is useful for debugging your projects!
        // ------------------------------------------------------------------------
        Debug.Log("This is in the start method.");
    }

    // Update is called once per frame
    void Update()
    {
        // ------------------------------------------------------------------------
        // Playing with the Debug.Log again.  
        // This message appears in the Console window once per frame. 
        // ------------------------------------------------------------------------
        Debug.Log("This is in the update method.");
        Debug.Log("Number: " + number + "  Word: " + word);
    }
}
