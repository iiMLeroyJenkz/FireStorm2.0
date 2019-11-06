using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private static int DEFAULT_RUN_SPEED = 5;

    public GameManager m_gameManager;

    private Animator m_animator;
    private Rigidbody2D m_rigidBody;
    private float m_horizontalMovement;
    private float m_verticalMovement;
    public float jumpForce = 1.0f;
    private bool onGround = false;
    private bool letGoOfJump = false;
    private bool isFalling = true;
    Animator animator;

    [HideInInspector]
    public float moveSpeed;
    [HideInInspector]
    public bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        if (m_gameManager == null)
        {
            m_gameManager = FindObjectOfType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ResetAnimDirection();

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                isMoving = true;

                if (Input.GetAxisRaw("Jogging") != 0)
                {
                    if (m_horizontalMovement < 0)
                    {
                        m_animator.SetBool("Running", true);
                    }
                    else
                    {
                        m_animator.SetBool("Running", true);
                    }
                }
            }
        else
        {
            isMoving = false;
            m_animator.SetLayerWeight(1, 0);
            m_animator.SetLayerWeight(2, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = DEFAULT_RUN_SPEED * 2;
        }
        else
        {
            moveSpeed = DEFAULT_RUN_SPEED;
            m_animator.SetLayerWeight(2, 0);
        }
    }
    private void FixedUpdate()
    {



        Vector3 velocity = new Vector3();
        float xSpeed = 0.0f;
        float ySpeed = GetComponent<Rigidbody2D>().velocity.y;

        xSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButton("Jumping") && !letGoOfJump && !onGround && !isFalling && GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            isFalling = true;
        }

        if (Input.GetButton("Jumping"))
        {
            animator.SetBool("Jumping", true);
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

        if (Input.GetButton("Jump") && onGround && letGoOfJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
            letGoOfJump = false;
            isFalling = false;

        }

    }
    private void ResetAnimDirection()
    {
        m_animator.SetBool("Jogging", false);
        m_animator.SetBool("Running", false);
        m_animator.SetBool("Crouching", false);
        m_animator.SetBool("CrouchShooting", false);
        m_animator.SetBool("Jumping", false);
        m_animator.SetBool("Shooting", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            animator.SetBool("Jumping", false);
        }
        else if (collision.gameObject.tag == "Coin")
        {


            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "DeathFloor")
        {
            Debug.Log("PLAYER DEATH");
            SceneManager.LoadScene(5);
        }
    }
}


