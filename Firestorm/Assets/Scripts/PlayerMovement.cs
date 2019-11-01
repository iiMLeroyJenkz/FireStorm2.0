using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private static int DEFAULT_RUN_SPEED = 5;

    public GameManager m_gameManager;

    private Animator m_animator;
    private Rigidbody2D m_rigidBody;
    private float m_horizontalMovement;
    private float m_verticalMovement;

    [HideInInspector]
    public float moveSpeed;
    [HideInInspector]
    public bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
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
                m_animator.SetLayerWeight(1, 1);

                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    if (m_horizontalMovement < 0)
                    {
                        m_animator.SetBool("Left", true);
                    }
                    else
                    {
                        m_animator.SetBool("Right", true);
                    }
                }
            }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (m_verticalMovement < 0)
            {
                m_animator.SetBool("Forward", true);
            }
            else
            {
                m_animator.SetBool("Backward", true);
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
        m_horizontalMovement = Input.GetAxisRaw("Horizontal");

        m_verticalMovement = Input.GetAxisRaw("Vertical");

        m_rigidBody.velocity = new Vector2(m_horizontalMovement * moveSpeed, m_verticalMovement * moveSpeed);

    }
    private void ResetAnimDirection()
    {
        m_animator.SetBool("Left", false);
        m_animator.SetBool("right", false);
        m_animator.SetBool("Forward", false);
        m_animator.SetBool("Backward", false);
    }
}
