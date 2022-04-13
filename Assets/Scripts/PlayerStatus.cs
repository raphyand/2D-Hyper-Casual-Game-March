using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

     private static PlayerStatus instanceBob;

     public static PlayerStatus Instance { get { return instanceBob; } }

     static int score = 0;
     static float timeElapsed;

     private void Awake()
     {
          if (instanceBob != null && instanceBob != this)
          {
               Destroy(this.gameObject);
          }
          else
          {
               instanceBob = this;
               //DontDestroyOnLoad(gameObject);
          }
     }


     ParticleSystem myParticleSystem;
     SpriteRenderer mySpriteRender;
     BoxCollider2D myBoxCollider2D;
     Rigidbody2D myRigidBody2D;

     [SerializeField]
     private GameObject mustache;

     float timeToDestroy;
     bool isAlive;
     bool isProtected;

    // Start is called before the first frame update
    void Start()
    {
          isAlive = true;
          myBoxCollider2D = GetComponent<BoxCollider2D>();
          mySpriteRender = GetComponent<SpriteRenderer>();
          myParticleSystem = GetComponentInChildren<ParticleSystem>();
          myRigidBody2D = GetComponent<Rigidbody2D>();
          timeToDestroy = myParticleSystem.main.duration;
          Debug.Log(timeToDestroy);
          DontDestroyOnLoad(gameObject);
     }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.CompareTag("Damage"))
          {
               if (isProtected)
               {
                    DeactivateMustache();
               }
               else
               {
                    Die();
               }
               
          }
     }


     // Update is called once per frame
     void Update()
    {
          DestroySelf();
    }

     void DestroySelf()
     {
          if (isAlive == false)
          {
               timeToDestroy -= Time.deltaTime;
               Debug.Log(timeToDestroy);
               if (timeToDestroy <= 0)
               {
                    Destroy(gameObject);
               }
          }
     }

     void Die()
     {
          mySpriteRender.enabled = false;
          myParticleSystem.Play();
          myBoxCollider2D.enabled = false;
          myRigidBody2D.simulated = false;
          isAlive = false;
     }

     public void ActivateMustache()
     {
          mustache.SetActive(true);
          isProtected = true;
     }

     void DeactivateMustache()
     {
          mustache.SetActive(false);
          isProtected = false;
     }

}
