using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("KILLED");
            Destroy(collision.gameObject);
        }
    }
    public float Speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        Debug.Log("oi m8");

    }
}
