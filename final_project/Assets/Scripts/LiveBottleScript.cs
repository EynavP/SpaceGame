using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveBottleScript : MonoBehaviour
{
    float livesGive = 30f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().AddHP(livesGive);
            Destroy(gameObject);
        }
    }
}
