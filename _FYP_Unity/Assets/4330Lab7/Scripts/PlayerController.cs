using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float inputX;

    private Rigidbody2D rb;

    private bool faceRight = true;

    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    public int maxJumps;
    private int remainJumps;

    public Animator myAnim;
    
    public Vector3 respawnPosition;
    public LevelManager levelManager;

    private float inputY;
    public float ladderDistance;
    public LayerMask whatIsLadder;

    public GameObject stompCheck;

    public AudioSource jumpSound, hurtSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainJumps = maxJumps;
        myAnim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (faceRight == false && inputX > 0)
        {
            Flip();
        }
        else if (faceRight == true && inputX < 0)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        if (isGrounded)
        {
            remainJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && remainJumps >0)
        {
            rb.velocity = Vector2.up * jumpForce;
            remainJumps--;
            jumpSound.Play();
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderDistance, whatIsLadder);

        if (Input.GetKey(KeyCode.UpArrow) && hitInfo.collider != null)
        {
            inputY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputY * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2.5f;
        }
    
        myAnim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlatform")
        {
            levelManager.RespawnPlayer();
        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (rb.velocity.y < 0)
        {
            stompCheck.SetActive(true);
        }
        else
        {
            stompCheck.SetActive(false);
        }
    }
}