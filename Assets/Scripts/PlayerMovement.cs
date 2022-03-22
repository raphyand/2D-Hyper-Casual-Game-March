using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

     [SerializeField] private float moveSpeed = 2.0f;
     Rigidbody2D myRigidBody2D;


     // Vector of the previous move input.  Used for determining
     // what direction the object should face when movement stops.
     // NOTE: Taken from Baklava, could adapt to something else.

     // Vector of the latest move input.
     private Vector2 movementVector;

    // Start is called before the first frame update
    void Start()
    {
          myRigidBody2D = GetComponent<Rigidbody2D>();
          movementVector = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
          myRigidBody2D.MovePosition(new Vector2(transform.position.x, transform.position.y) + movementVector);
     }


     public void OnMove(InputAction.CallbackContext context)
     {
          Move(context.ReadValue<Vector2>());
        
     }

     private void Move(Vector2 moveVector)
     {
          movementVector = moveVector * moveSpeed * Time.fixedDeltaTime;
          //transform.position += new Vector3(movementVector.x, movementVector.y, 0);
          //myRigidBody2D.MovePosition(new Vector2(transform.position.x, transform.position.y) + movementVector);
     }

}
