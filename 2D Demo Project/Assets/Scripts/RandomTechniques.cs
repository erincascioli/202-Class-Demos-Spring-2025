using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTechniques : MonoBehaviour
{
    // ----------------------------------------------------------------------------------------
    // Fields of the class with references
    // ----------------------------------------------------------------------------------------
    // Field for each prefab - needed if not using a list.
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    // I prefer using a List of GO's to hold references to each prefab
    public List<GameObject> prefabList;

    // Reference to the specific prefab that I instantiated
    public GameObject spawnedShape;

    // Timer for spawning
    private float timer;

    // DONT NEED A RANDOM OBJECT! Call Random.Range() whenever needed!



    void Start()
    {
        // ----------------------------------------------------------------------------------------
        // Pseudo-random Use
        // ----------------------------------------------------------------------------------------

        // Spawn one of three prefabs at the start of the game.
        PseudorandomSpawn();
    }


    void Update()
    {
        // ----------------------------------------------------------------------------------------
        // Non-Uniform Use
        // ----------------------------------------------------------------------------------------

        // Every 2 seconds, spawn a new shape with NonUniformSpawn() method.
        timer += Time.deltaTime;
        if(timer > 2)
        {
            NonUniformSpawn();
            timer = 0;
        }
    }


    /// <summary>
    /// Pseudorandom algorithm, where there is an equal chance of spawning any of the 3 shapes.
    /// </summary>
    public void PseudorandomSpawn()
    {
        // Generate a random value of 1, 2 or 3.
        int randomValue = Random.Range(1, 4); 

        // Depending on the returned value, choose one of the 3 prefabs to instantiate.
        // All prefabs are at (0, 0, 0) and no rotation.
        if (randomValue == 1)
        {
            spawnedShape = Instantiate(
                prefab1,
                Vector3.zero,
                Quaternion.identity);
        }
        else if (randomValue == 2)
        {
            spawnedShape = Instantiate(
                prefab2,
                new Vector3(0, 0, 0),
                Quaternion.identity);
        }
        else
        {
            spawnedShape = Instantiate(
                prefab3,
                new Vector3(0, 0, 0),
                Quaternion.identity);
        }

        // ********************************************************************
        // FYI:
        // All that code could be reduced to this, if a list (or other collection)
        //   of prefabs is used!
        // ********************************************************************
        /*
        int randomIndex = Random.Range(0, prefabList.Count);  // 0, 1 or 2 (whatever to the count of list)
        spawnedShape = Instantiate(
                prefabList[randomIndex],
                Vector3.zero,
                Quaternion.identity);
        */
    }


    /// <summary>
    /// Non-Uniform algorithm, where we can guide the outcomes based on percentages.
    /// </summary>
    public void NonUniformSpawn()
    {
        // Percent chances:
        // Circle:  20  (list index 0)
        // Triangle: 30 (list index 1)
        // Square: 50   (list index 2)


        // Generate a random percentage
        int randomChance = Random.Range(1, 101);        // 1 - 100 (whatever to the count of list)

        // Generate a random position in the game view
        Vector3 positionOfShape = new Vector3(
            Random.Range(-10f, 10f),                    // X: -10 to 10
            Random.Range(-5f, 5f),                      // Y: -5 to 5
            0);                                         // Z: Always 0 to remain in front of camera

        // 50% chance of a square
        if(randomChance < 51)
        {
            spawnedShape = Instantiate(
                prefabList[2],
                positionOfShape,
                Quaternion.identity);
        }
        // 30% chance of a triangle
        else if(randomChance < 81)
        {
            spawnedShape = Instantiate(
                prefabList[1],
                positionOfShape,
                Quaternion.identity);
        }
        // 20% chance of a circle
        else
        {
            spawnedShape = Instantiate(
                prefabList[0],
                positionOfShape,
                Quaternion.identity);
        }

        // ********************************************************************
        // FYI:
        // The conditional statements above could be reduced by initializing a
        //   random index and calling Instantiate once!
        // ********************************************************************
        /*
        // Generate a random percentage
        int randomChance = Random.Range(1, 101);        // 1 - 100 (whatever to the count of list)

        // Generate a random position in the game view
        Vector3 positionOfShape = new Vector3(
            Random.Range(-10f, 10f),                    // X: -10 to 10
            Random.Range(-5f, 5f),                      // Y: -5 to 5
            0);                                         // Z: Always 0 to remain in front of camera

        // Save which index must be instantiated
        int chosenIndex;

        // Determine which index from the list
        if (randomChance < 51)              // 50% chance of a square
            chosenIndex = 2;

        else if (randomChance < 81)         // 30% chance of a triangle
            chosenIndex = 1;

        else                                // 20% chance of a circle
            chosenIndex = 0;

        // Instantiate the shape
        spawnedShape = Instantiate(
                prefabList[chosenIndex],
                positionOfShape,
                Quaternion.identity);
        */
    }
}
