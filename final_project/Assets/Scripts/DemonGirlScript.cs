using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGirlScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3;
    int currentWayPoint = 0;
    Vector3 target1, moveDirection;

    // Update is called once per frame
    void Update()
    {

        target1 = waypoints[currentWayPoint].position;
        moveDirection = target1 - transform.position;
        if (moveDirection.magnitude < 1)
        {
            currentWayPoint = ++currentWayPoint % waypoints.Length;
        }
        transform.LookAt(target1);
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;

    }
}
