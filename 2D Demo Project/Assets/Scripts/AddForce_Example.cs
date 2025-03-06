using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce_Example : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Vector3 jumpDirection;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the direction vector up for success! Accuracy.
        jumpDirection.Normalize();
        jumpDirection *= jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        //Jump();
    }

    public void Jump()
    {
        rigid.AddForce(jumpDirection);
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Jump();
    }
    
}
