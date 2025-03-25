using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSculpt : MonoBehaviour
{
    public TerrainData terrainData;
    public float perlinStep = 0.01f;

    void Start()
    {
        SetTerrainValues();
    }

    void Update()
    {
        
    }

    public void SetTerrainValues()
    {
        // Requires:
        // X and Y bases (remembering that a Terrain is a 2D mesh!) correspond to
        //   rows and columns in the array
        // array of floats that will be assigned to the terrain
        //    where the array size should match the Terrain resolution (1024 x 1024)

        int terrainResolution = terrainData.heightmapResolution;        //1024
        float[,] heightValues = new float[terrainResolution, terrainResolution];

        /*
        // Try this with completely random values, where the heights are between 0 and 1.
        for(int x = 0; x < terrainResolution; x++)
        {
            for(int y = 0; y < terrainResolution; y++)
            {
                heightValues[x, y] = Random.Range(0f, 1f);
            }
        }
        */

        // Now, try this with Perlin noise!
        float perlinX = 0f;
        float perlinY = 0f;

        // Go row by row down the Perlin noise array of values
        for (int x = 0; x < terrainResolution; x++)
        {
            // Iterate through each column in the row
            for (int y = 0; y < terrainResolution; y++)
            {
                // Sample the value at that (x,y) coordinate in the Perlin array
                heightValues[x, y] = 
                    Mathf.PerlinNoise(perlinX, perlinY);

                // Increase the column for each vertex
                perlinY += perlinStep;
            }

            // Ready for the next row?
            // Reset the column back to 0
            // And increase the row by 1.
            perlinX += perlinStep;
            perlinY = 0f;
        }

        terrainData.SetHeights(0, 0, heightValues);
    }
}
