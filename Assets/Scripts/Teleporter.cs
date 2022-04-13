using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
     [SerializeField]
     Transform areaToTeleportTo;


     [SerializeField] 
     private bool levelPorter;

     [SerializeField]
     private bool destinationPorter;

     private AudioSource myAudioSource;

     private SceneHandler mySceneHandler;

     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.CompareTag("Player")){
               Debug.Log("Player here!");
               if (levelPorter)
               {
                    TeleportToOtherTeleporter(collision.gameObject);
               }
               else
               {
                    TeleportToNextLevel();
               }
               
          }
          
     }

    // Start is called before the first frame update
    void Start()
    {
          myAudioSource = GetComponent<AudioSource>();
          mySceneHandler = FindObjectOfType<SceneHandler>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

     void TeleportToOtherTeleporter(GameObject player)
     {
          if (destinationPorter == false)
          {
               SoundManager.Instance.PlaySound(myAudioSource.clip);
               player.transform.position = areaToTeleportTo.position;
          }
          
     }

     void TeleportToNextLevel()
     {
          if (!levelPorter)
          {
               SoundManager.Instance.PlaySound(myAudioSource.clip);
               mySceneHandler.LoadNextLevel();
          }
          
     }

}
