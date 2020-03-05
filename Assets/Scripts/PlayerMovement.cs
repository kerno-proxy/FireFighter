using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Attributes")]
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    private Rigidbody myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Debug.Log("Velocity " + myRigidBody.velocity);
    }

    private void Movement()
    {
        myRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, myRigidBody.velocity.y, 0f);
    }
    private void Jump()
    {
        Debug.Log("Attempting jump");
        myRigidBody.AddForce(new Vector3(myRigidBody.velocity.x, jumpForce, 0f));
    }
}
