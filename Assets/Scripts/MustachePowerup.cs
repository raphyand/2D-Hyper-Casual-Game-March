using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustachePowerup : MonoBehaviour
{
     private AudioSource myAudioSource;
     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.CompareTag("Player"))
          {
               FindObjectOfType<PlayerStatus>().ActivateMustache();
               SoundManager.Instance.PlaySound(myAudioSource.clip);
               Destroy(gameObject);
          }
          
     }


     // Start is called before the first frame update
     void Start()
    {
          myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
