using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     [SerializeField]
     public AudioClip[] playerSFX;
     [SerializeField]
     public AudioClip[] interactablesSFX;
     [SerializeField]
     public AudioClip[] UISFX;

     private AudioSource myAudioSource;

     private static SoundManager instance;

     public static SoundManager Instance { get { return instance; } }


     private void Awake()
     {
          if (instance != null && instance != this)
          {
               Destroy(this.gameObject);
          }
          else
          {
               instance = this;
               DontDestroyOnLoad(gameObject);
          }
     }



     // Start is called before the first frame update
     void Start()
    {
          myAudioSource = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PlaySound(AudioClip ads)
     {
          myAudioSource.PlayOneShot(ads);
     }

}
