using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 700f;

    

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "HP:" + hitPoints);

    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    public void AddHP(float lives)
    {
        hitPoints += lives;
    }
}
