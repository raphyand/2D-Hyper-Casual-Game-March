using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
     [SerializeField]
     //private GameObject Bullet;
     private Projectile myProjectile;
     [SerializeField]
     private Transform firePoint;
     Rigidbody2D bulletRigidBody2D;
     [SerializeField]
     Vector2 fireDirection;
     [SerializeField]
     private float timeBtwShots = 3f;
     private float timeShotRefresh;
     private void OnDrawGizmosSelected()
     {
          Gizmos.color = Color.red;
          Vector2 direction = transform.TransformDirection(Vector2.down) * 3;
          Gizmos.DrawRay(transform.position, direction);
     }

     // Start is called before the first frame update
     void Start()
    {
          //fireDirection = transform.TransformDirection(Vector2.down) * 3;
          timeShotRefresh = timeBtwShots;
          Fire();
    }

    // Update is called once per frame
    void Update()
    {
          Fire();
    }

     private void Fire()
     {
          timeBtwShots -= Time.deltaTime;
          if (timeBtwShots <= 0)
          {
               Instantiate(myProjectile, firePoint);
               timeBtwShots = timeShotRefresh;
          }
          
     }

}
