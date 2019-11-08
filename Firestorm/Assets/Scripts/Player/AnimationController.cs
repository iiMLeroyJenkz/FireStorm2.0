using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
  
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isJogging", true);



        }else
        {
            anim.SetBool("isJogging", false);
        }
      if(Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isJoggingleft",true);
        }
        else
        {
            anim.SetBool("isJoggingleft", false);
        }
      
      
      if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        } 
      if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Crouch");
        }
      if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Shoot");
        }
      
    }

}
