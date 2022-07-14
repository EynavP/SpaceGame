using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors2_open : MonoBehaviour
{
    Animator animator;
    bool doorOpen;
    [SerializeField] GameObject enemy;
    public bool isDied=false;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (isDied)
        {
            light.enabled = true;
            animator.SetTrigger("Open");
        }
    }
}
