using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

     [SerializeField] private float moveSpeed = 2.0f;
     [SerializeField] private float jumpHeight = 5.0f;
     Rigidbody2D myRigidBody2D;
     CircleCollider2D myCircleCollider2D;
     int numJumps = 2;
     int jumpsLeft;
     [SerializeField]
     private bool canJump;
     [SerializeField]
     LayerMask canJumpOn;

     // Vector of the previous move input.  Used for determining
     // what direction the object should face when movement stops.
     // NOTE: Taken from Baklava, could adapt to something else.

     // Vector of the latest move input.
     private float moveAxis = 0f;

     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.CompareTag("Platform"))
          {
               Debug.Log("Triggered!");
               canJump = true;
               jumpsLeft = numJumps;
          }
     }


/*     private void OnTriggerExit2D(Collider2D collision)
     {
          if (collision.CompareTag("Platform"))
          {
               canJump = false;
               Debug.Log(canJump);
          }
     }*/

     // Start is called before the first frame update
     void Start()
    {
          myRigidBody2D = GetComponent<Rigidbody2D>();
          myCircleCollider2D = GetComponent<CircleCollider2D>();
          jumpsLeft = numJumps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
          Move();
    }


     // NOTE: This is mainly to GET THE INPUT CONTEXT FLOATS
     public void OnMove(InputAction.CallbackContext context)
     {
          moveAxis = context.ReadValue<float>();
     }

     public void OnJump(InputAction.CallbackContext context)
     {
          if (context.started &&
               canJump == true && 
               jumpsLeft > 0)
          {
               Jump();
          }
          
     }

     private void Jump()
     {
          Debug.Log("Jump!");
          myRigidBody2D.velocity = Vector2.up * jumpHeight;
          jumpsLeft--;
     }

     // Handle main move logic
     private void Move()
     {
          Vector2 currentposition = transform.position;
          currentposition.x += moveAxis * moveSpeed * Time.deltaTime;
          transform.position = currentposition;
     }

}
