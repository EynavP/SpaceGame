using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    [SerializeField] GameObject doors;
  
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            if (doors != null)
                doors.GetComponent<Doors2_open>().isDied = true;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
