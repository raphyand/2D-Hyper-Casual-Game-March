using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

     int value;
     AudioSource myAudioSource;

     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.CompareTag("Player"))
          {
               Debug.Log("Add a point!");
               GameManager.Instance.addToScore(value);
               SoundManager.Instance.PlaySound(myAudioSource.clip);
               Destroy(gameObject);
          }

     }

     // Start is called before the first frame update
     void Start()
    {
          myAudioSource = GetComponent<AudioSource>();
          value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
