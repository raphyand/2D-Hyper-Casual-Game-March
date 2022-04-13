using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

     int currentSceneIndex;
     int nextSceneIndex;


     // Start is called before the first frame update
     void Start()
    {
          currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          nextSceneIndex = ++currentSceneIndex;
     }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void LoadNextLevel()
     {
          SceneManager.LoadScene(nextSceneIndex);
     }

     public void Quit()
     {
          Application.Quit();
     }

}
