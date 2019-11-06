using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 200;
    public int damage = 40;
    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health < 0)
        {
            Die();
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
