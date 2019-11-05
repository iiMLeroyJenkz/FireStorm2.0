using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void LateUpdate()
    {
        //camera's position in a variable temp
        Vector3 temp = transform.position;

        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        transform.position = temp;

        
    }
}
