using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOver;

    private void Start()
    {
        GameOver.enabled = false;
         
    }
    public void HandleDeath()
    {
        GameOver.enabled = true;
       // Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }

}
