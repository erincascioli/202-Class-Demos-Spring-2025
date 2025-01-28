using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------------------------------------------------------------------------
// Cube Spawner script - demonstrates usage of the Instantiate  method.
// ------------------------------------------------------------------------

/// <summary>
/// Spawns multiple prefab instances at a set interval.
/// </summary>
public class CubeSpawner : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // To Instantiate a prefab, the prefab must be referenced in the script.
    // As the prefab already exists within the game, this reference can be
    //   assigned by dragging-and-dropping in the Inspector.
    // ------------------------------------------------------------------------
    public GameObject prefabTemplate;

    // ------------------------------------------------------------------------
    // The Instantiate method returns a reference to a single GameObject.
    // That single instance can be captured by a field of the class.
    // Alternately, if Instantiate is called in a loop or every frame,
    //   the GameObject references can be "saved" in an array, list, or other
    //   chosen data structure. 
    // ------------------------------------------------------------------------
    public GameObject singlePrefabInstance;
    public List<GameObject> prefabInstanceList;

    // ------------------------------------------------------------------------
    // A simple timer facilitates an action occurring every X frames
    // ------------------------------------------------------------------------
    public int timer;
    public int frameInterval;                   // Set to 200 in the Inspector.
    public int numberInstancesBeforeDestroy;    // Set to 10 in Inspector.

    
    void Start()
    {
        // ------------------------------------------------------------------------
        // Rotations require Quaternions, not Vector3's.
        // ------------------------------------------------------------------------
        singlePrefabInstance = Instantiate(
            prefabTemplate,             // Which prefab to clone?
            new Vector3(2, 2, 0),       // Where to position the clone?
            Quaternion.identity);       // Represents no rotation
    }


    void Update()
    {
        // ------------------------------------------------------------------------
        // Once per frame, increase the timer. This will keep tract of the number
        //   of frames that have passed. 
        // Once a set number of frames have completed, use the Instantiate method
        //   to spawn new instances of the prefab. 
        // Destroy a random one once a certain number of instances have been made.
        // That will keep the number of prefab instances reasonable for the gameplay,
        //   allowing the FPS to remain high.
        // ------------------------------------------------------------------------
        
        // Increase the timer once per frame
        timer++;

        // Did the timer reach the set number of frames? 
        if (timer == frameInterval)
        {
            // Instantiate a new instance of the prefab!
            GameObject prefabInstance = Instantiate(
                prefabTemplate,             // Which prefab?
                new Vector3(
                    Random.Range(-8f, 8f),    // Random X
                    Random.Range(3f, 10f),  // Random Y
                    0),                     // Always 0 Z
                Quaternion.identity);       // No rotation

            // ------------------------------------------------------------
            // Without "saving" the returned reference somewhere in your game,
            //   the locally-declared variable "prefabInstance" is overwritten
            //   each Update call and you, the programmer, only have direct 
            //   direct access to the most recently-instantiated prefab instance.
            // ------------------------------------------------------------
            // Add the instantiated object to the list of instances.
            prefabInstanceList.Add(prefabInstance);

            // Reset the timer back to 0!
            timer = 0;

            // After 10 instances have been created, destroy one instance at random.
            if(prefabInstanceList.Count >= numberInstancesBeforeDestroy)
            {
                int indexToRemove = Random.Range(0, prefabInstanceList.Count - 1);

                // ------------------------------------------------------------
                // Destroy will remove a GameObject from the hierarchy.  
                // It will *not* remove it from the list.
                // Without both destroying AND remoing from the list, the list
                //   will contain "empty" elements, resulting in a null reference
                //   when one of those are accessed.
                // ------------------------------------------------------------
                Destroy(prefabInstanceList[indexToRemove]);
                prefabInstanceList.RemoveAt(indexToRemove);
            }
        }
    }
}
