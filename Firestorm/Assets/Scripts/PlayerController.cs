using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;
	const bool SONIC = false, TAILS = false, KNUCKLES = false;
    private bool onGround = false;
    private bool letGoOfJump = false;
    private bool isFalling = true;
	Animator animator;



    // Start is called before the first frame update
    void Start()
    {
		 animator = GetComponent<Animator>();
        /*
          if(SONIC)
		{
			moveSpeed = 12.0f;
			jumpForce = 8.0f;
		}
		else if(TAILS)
		{
			moveSpeed = 8.0f;
			jumpForce = 12.0f;
		}
		else if(KNUCKLES)
		{
			moveSpeed = 8.0f;
			jumpForce = 8.0f;
		}
        */
     }
        


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3();
        float xSpeed = 0.0f;
        float ySpeed = GetComponent<Rigidbody>().velocity.y;

        xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if(Input.GetButton("Jump") && !letGoOfJump && !onGround && !isFalling && GetComponent<Rigidbody>().velocity.y <= 0)
        {
            isFalling = true;
			
        }

        if (Input.GetButton("Jump"))
        {
			animator.SetBool("Jumping",true);
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
        GetComponent<Rigidbody>().velocity = velocity;

        if (Input.GetButton("Jump")&& onGround && letGoOfJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            letGoOfJump = false;
            isFalling = false;
			
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
			animator.SetBool("Jumping",false);
        }
		 else if(collision.gameObject.tag == "Coin")
        {
            Debug.Log("COIN COLLECTED");
			//ADD TO SCORE + 1
			//look for tagged item to increment score

			//coinObject.text = coinsCollected;
			  Destroy(collision.gameObject);
			// SceneManager.LoadScene( "GameOver");
        }
        else if(collision.gameObject.tag == "DeathFloor")
        {
            Debug.Log("PLAYER DEATH");
			  SceneManager.LoadScene(5);
			// SceneManager.LoadScene( "GameOver");
        }
    }
}
