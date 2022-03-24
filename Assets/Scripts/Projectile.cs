using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
     Rigidbody2D myRigidBody2D;
     CircleCollider2D myCircleCollider2D;
     [SerializeField]
     private float speed = .5f;

     [SerializeField]
     Vector2 forwardVector;
     // Start is called before the first frame update

     private void OnCollisionEnter2D(Collision2D collision)
     {
          Destroy(gameObject);
     }

     void Start()
    {
          //forwardVector = new Vector2(transform.forward.x, transform.forward.y);
          myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
          myRigidBody2D.velocity = new Vector2(transform.up.x, transform.up.y) * -speed;//new Vector2(0, -1) * speed;//* Time.fixedDeltaTime;
    }
}
