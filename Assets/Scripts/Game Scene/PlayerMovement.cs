using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraObject;
    public float acceleration;
    public float walkAccelerationRatio;

    public float maxWalkSpeed;
    public float deaccelerate = 2;
    [HideInInspector]
    public Vector2 horizontalMovement;

    [HideInInspector]
    public float walkDeaccelerateX;
    [HideInInspector]
    public float walkDeaccelerateZ;

    [HideInInspector]
    public bool isGrounded = true;
    Rigidbody playerRigidBody;
    public float jumpVelocity = 500;
    float maxSlope = 45;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForce(0, jumpVelocity, 0);
        }
    }

    void Move()
    {
        //  Controlling the limit of player by measuring the Vector 3 magnitude and then measuring and normalizing that vector
        horizontalMovement = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.z);

        if(horizontalMovement.magnitude > maxWalkSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxWalkSpeed;
        }
        playerRigidBody.velocity = new Vector3(horizontalMovement.x, playerRigidBody.velocity.y, horizontalMovement.y); // Controlling only X and Z speed of the cube movement

        //  Rotating the player according to MouseLook current Y variable so player looks where camera is looking
        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<MouseLook>().currentY, 0);

        //  Moving here
        if (true) //  Complete control when player is grounded
        {
            playerRigidBody.AddRelativeForce(
                Input.GetAxis("Horizontal") * acceleration,
                0,
                Input.GetAxis("Vertical") * acceleration
            );
        }
        //else
        //{
        //    playerRigidBody.AddRelativeForce(
        //        Input.GetAxis("Horizontal") * acceleration * walkAccelerationRatio,
        //        0,
        //        Input.GetAxis("Vertical") * acceleration * walkAccelerationRatio
        //    );
        //}

        //  Adds friction to player's movement
        
        float xMove = Mathf.SmoothDamp(playerRigidBody.velocity.x, 0, ref walkDeaccelerateX, deaccelerate);
        float zMove = Mathf.SmoothDamp(playerRigidBody.velocity.z, 0, ref walkDeaccelerateZ, deaccelerate);
        playerRigidBody.velocity = new Vector3(xMove, playerRigidBody.velocity.y, zMove);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            if(Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
            {
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("Plane"))
        {
            isGrounded = false;
        }
    }
}
