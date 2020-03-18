using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Attributes")]
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float dodgeForce = 1f;
    [SerializeField] float dodgeCoolDown = 1f;
    private Rigidbody myRigidBody;
    private bool isInTheAir = false;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
         isInTheAir = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        
        if (isInTheAir) 
        {
            return;
        }
        //bool check above ensures that no movements below can be performed while player is in the air.
        
            Movement();
        
        if (Input.GetButtonDown("Jump"))
        {
             Jump();
        }
        if (Input.GetButtonDown("Dodge"))
        {
            Dodge();
        }
    }

    private void Movement()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(Input.GetAxis("Horizontal")), transform.localScale.y, transform.localScale.z);
            myRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, myRigidBody.velocity.y, 0f);
        }
        
        
        
    }
    private void Jump()
    {
        
            myRigidBody.AddForce(new Vector3(0f, jumpForce, 0f));
        
    }
    private void Dodge()
    {
        Debug.Log("Attempting a dodge"); 
        
        myRigidBody.AddForce(Mathf.Abs(dodgeForce)*Mathf.Sign(transform.localScale.x),dodgeForce*0.1f,0,ForceMode.Impulse);
    }
}
