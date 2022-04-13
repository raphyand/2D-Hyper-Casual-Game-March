using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
     [SerializeField] private GameObject playerToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void spawnPlayer()
     {
          //DontDestroyOnLoad(PlayerStatus.Instance);
          //Instantiate(PlayerStatus.Instance);
          PlayerStatus.Instance.transform.position = gameObject.transform.position;
     }

     public void respawnPlayer()
     {
          if (PlayerStatus.Instance == null)
          {
               Debug.Log("New Instance of Floppy Bob created.");
               GameObject newBob = Instantiate(playerToSpawn, transform);
               newBob.transform.parent = null;
          }
     }

}
