using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   private int currentScene;
   public void ReloadGame()
    {
        SceneManager.LoadScene(2);
       // Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    public void Start()
    {
        currentScene = (SceneManager.GetActiveScene().buildIndex);
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(currentScene+1);
            
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(currentScene+1);
        Debug.Log(currentScene+1);
    }
}
