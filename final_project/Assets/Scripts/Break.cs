using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;
    public float breakFource;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            BreakTheThing();
    }

    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);

        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 fource = (rb.transform.position - transform.position).normalized * breakFource;
            rb.AddForce(fource);
        }
        Destroy(gameObject);
    }
}
