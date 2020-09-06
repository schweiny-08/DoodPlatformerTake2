using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player's movement speed
    public float speed;
    public float jumpSpeed;


    private Rigidbody2D rb;
    private float moveVelocity;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded;
    private int jump, health;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        moveVelocity = speed * Time.deltaTime;
        isGrounded = true;
        jump = 0;
        anim = GetComponent<Animator>();
        health = 10;
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    public void UpdateHealth(int h) {
        health += h;
        Debug.Log(health);
        if (health <= 0) {
            gm.Death(gameObject);
            gm.Respawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            rb.gravityScale = 2.1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sr.flipX = true;
           anim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sr.flipX = false;
            anim.SetBool("isWalking", true);
        }
        else {
            //Player is idle
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || jump < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                isGrounded = false;
                jump++;
            }
        }


    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
        {
            if (!isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
        jump = 0;
    }
}