using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    Animator animator;
    bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorControl("Open");
        }
    }

    private void DoorControl(string state)
    {
        animator.SetTrigger(state);
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorControl("Close");
        }
    }
}
