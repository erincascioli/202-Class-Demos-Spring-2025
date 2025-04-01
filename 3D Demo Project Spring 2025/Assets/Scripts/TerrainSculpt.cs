using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSculpt : MonoBehaviour
{
    /// <summary>
    /// Access to the Terrain's heightmap
    /// </summary>
    public TerrainData terrainData;

    /// <summary>
    /// Float array that holds values between 0 and 1. 
    /// Used for setting heightmap values.
    /// </summary>
    private float[,] heightmapValues;

    /// <summary>
    /// Change in time step for retrieving Perlin values
    /// </summary>
    public float timeStep;


    void Start()
    {
        // Random.Range generates uniformly random height values
        //SetRandomHeights();

        // Perlin noise generates smooth height changes
        SetPerlinRandomHeights();
    }


    /// <summary>
    /// Fills the Terrain's heightmap with randomly generated values between 0 and 1.
    /// </summary>
    public void SetRandomHeights()
    {
        // Initialize the array of heightmap values
        heightmapValues = 
            new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        // Generate random values for all vertices in the Terrain mesh
        for(int row = 0; row < terrainData.heightmapResolution; row++)
        {
            for(int col = 0; col < terrainData.heightmapResolution; col++)
            {
                heightmapValues[row, col] = Random.Range(0f, 1f);
            }
        }

        // Pass data to the Terrain
        terrainData.SetHeights(0, 0, heightmapValues);
    }


    /// <summary>
    /// Fills the Terrain's heightmap with values between 0 and 1.
    /// </summary>
    public void SetPerlinRandomHeights()
    {
        // Requires:
        // 1) X and Y base (remembering that a Terrain is a 2D mesh!) correspond to
        //   starting row and column in the heightmap values array
        // 2) array of floats that will be assigned to the terrain
        //    where the array size should match the Terrain resolution (1024 x 1024)

        // Initialize the array of heightmap values
        heightmapValues =
            new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        // Use these coordinates for sampling different values at increasing points in time.
        float xCoordinate = 0;
        float yCoordinate = 0;

        // Generate random values for all vertices in the Terrain mesh
        for (int row = 0; row < terrainData.heightmapResolution; row++)
        {
            for (int col = 0; col < terrainData.heightmapResolution; col++)
            {
                // Increase the x coordinate by the time step and sample at that spot
                xCoordinate += timeStep;
                heightmapValues[row, col] = Mathf.PerlinNoise(xCoordinate, yCoordinate);
            }

            // Reset the "column" and increase the "row" 
            xCoordinate = 0;
            yCoordinate += timeStep;
        }

        // Pass data to the Terrain
        terrainData.SetHeights(0, 0, heightmapValues);
    }
}
