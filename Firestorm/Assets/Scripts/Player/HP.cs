using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{

     private float health = 100;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / 100f;

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
}

