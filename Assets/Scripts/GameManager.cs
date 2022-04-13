using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

     private static GameManager instance;

     public static GameManager Instance { get { return instance; } }

     private PlayerStatus Bob;


     static int score = 0;
     static float timeElapsed;

     private void Awake()
     {
          if (instance != null && instance != this)
          {
               Destroy(this.gameObject);
          }
          else
          {
               instance = this;
          }
     }

     // Start is called before the first frame update
     void Start()
    {
          FindObjectOfType<PlayerSpawn>().spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
          MonitorPlayerStatus();
    }

     public void addToScore(int value)
     {
          score += value;
          Debug.Log("Current Score: " + score);
     }


     private void MonitorPlayerStatus()
     {
          if (PlayerStatus.Instance == null)
          {
               FindObjectOfType<PlayerSpawn>().respawnPlayer();
          }
     }

}
