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
}
