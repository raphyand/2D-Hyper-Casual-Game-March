using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

     [SerializeField] private float moveSpeed = 2.0f;
     [SerializeField] private float jumpHeight = 5.0f;

     private SpriteRenderer[] mySpriteRenderers;
     private AudioSource myAudioSource;
     private Animator myAnimator;
     private Rigidbody2D myRigidBody2D;
     private CircleCollider2D myCircleCollider2D;

     int numJumps = 2;
     int jumpsLeft;

     [SerializeField]
     private bool canJump;
     [SerializeField]
     private bool isMoving;
     [SerializeField]

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

     // Start is called before the first frame update
     void Start()
    {
          myAudioSource = GetComponentInChildren<AudioSource>();
          mySpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
          myRigidBody2D = GetComponent<Rigidbody2D>();
          myCircleCollider2D = GetComponent<CircleCollider2D>();
          myAnimator = GetComponent<Animator>();
          jumpsLeft = numJumps;
    }

     private void Update()
     {
          handleAnims();
          FlipSprite();
     }


     // Update is called once per frame
     void FixedUpdate()
    {
          Move();
    }

     private void FlipSprite()
     {
          if (moveAxis != 0)
          {
               transform.localScale = new Vector3(moveAxis, 
                    transform.localScale.y, transform.localScale.z);
          }
     }

     private void handleAnims()
     {
          //Debug.Log(moveAxis);
          if (Mathf.Abs(moveAxis) > 0)
          {
               isMoving = true;
               myAnimator.SetBool("IsMoving", isMoving);
          }
          else{
               isMoving = false;
               myAnimator.SetBool("IsMoving", isMoving);
          }
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
          myAudioSource.Play();
          myRigidBody2D.velocity = Vector2.up * jumpHeight;
          jumpsLeft--;
     }

     // Handle main move logic
     private void Move()
     {
          Vector2 currentposition = transform.position;
          currentposition.x += moveAxis * moveSpeed * Time.deltaTime;
          transform.position = currentposition;
          //Debug.Log(currentposition);
          //Debug.Log(moveAxis);
          //myRigidBody2D.velocity = Vector2.right * moveAxis * moveSpeed;
     }

}
