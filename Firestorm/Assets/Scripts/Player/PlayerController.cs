using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;
    private bool onGround = false;
    private bool letGoOfJump = false;
    private bool isFalling = true;
	Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
     }
        


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3();
        float xSpeed = 0.0f;
        float ySpeed = GetComponent<Rigidbody2D>().velocity.y;

        xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if(Input.GetButton("Jump") && !letGoOfJump && !onGround && !isFalling && GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            isFalling = true;
			
        }

        if (Input.GetButton("Jump"))
        {
			animator.SetBool("Jump",true);
            if (isFalling)
            {
                ySpeed = 0;
                letGoOfJump = true;
                isFalling = true;
				
            }
            else
            {
                letGoOfJump = true;
            }
        }

        velocity.x = xSpeed;
        velocity.y = ySpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;

        if (Input.GetButton("Jump")&& onGround && letGoOfJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
            letGoOfJump = false;
            isFalling = false;
			
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
			animator.SetBool("Jump",false);
        }
		 else if(collision.gameObject.tag == "Coin")
        {


			  Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "DeathFloor")
        {
            Debug.Log("PLAYER DEATH");
			  SceneManager.LoadScene(5);
        }
    }
}
