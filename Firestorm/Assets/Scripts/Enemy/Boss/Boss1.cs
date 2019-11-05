using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public int damage = 20;
    public int health = 100;
    public Slider healthBar;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Die();
        }
  
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Update()
    {
        healthBar.value = health;
    }
}

