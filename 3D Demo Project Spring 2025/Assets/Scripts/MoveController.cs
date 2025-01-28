using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Want to change the positions of several game objects in the scene
    // Want to control the floor, cube, and the ball.

    // Access to the cube's transform
    public GameObject myCube;

    // Access to the floor's transform
    public GameObject myFloor;

    // Access to the ball's transform
    public GameObject myBall;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Move the cube along the Y axis
        Vector3 positionCopy = myCube.transform.position;
        positionCopy.y += 0.005f;
        myCube.transform.position = positionCopy;
    }
}
