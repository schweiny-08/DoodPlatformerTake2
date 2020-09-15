using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player's movement speed
    public float speed;
    public float jumpSpeed;
    public Sprite deadDood;
    public AudioClip doodDeadAudio;


    private Rigidbody2D rb;
    private float moveVelocity;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded;
    private int jump;
    private GameMaster gm;
    private PlayerDamage pd;
    private HealthSystem hs;
    private bool isDead;
    private Vector2 doodSize;
    private AudioSource audio;

    public int health;
    public float knockback;
    public float knockbackCount;
    public float knockbackLength;
    public bool knockFromRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        moveVelocity = speed * Time.deltaTime;
        isGrounded = true;
        jump = 0;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        health = gm.GetMaxPlayerHealth();//Sets health to full
        pd = GameObject.FindWithTag("Enemy").GetComponent<PlayerDamage>();
        hs = GetComponent<HealthSystem>();
        isDead = false;
        doodSize = sr.size;
    }

    public bool IsDead() {
        return isDead;
    }

    public void UpdateHealth(int h) {
        Debug.Log("HERE "+health);
        health += h;
        
        gm.SetPlayerHealth(health);

        if (health == gm.GetMaxPlayerHealth())
            gm.InitialiseHearts();

        if (health <= 0) {

            isDead = true;
            rb.freezeRotation = false;
            transform.rotation *= Quaternion.Euler(0, 0, 90f);//10f = rotate speed

            audio.PlayOneShot(doodDeadAudio, 0.5f);
            //Debug.Log("Before");
            StartCoroutine(Pause());
            //Debug.Log("After");

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCount <= 0)
        {
            if (!isDead)
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
                else
                {
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
            else {
                //if is dead
                anim.runtimeAnimatorController = null;
                sr.sprite = deadDood;
                sr.size = doodSize;
            }
        }
        else {
            //If player is knocked by enemy

            if (knockFromRight)
                rb.velocity = new Vector2(-knockback, knockback);
            else
                //If player is knocked from left
                rb.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
            
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

    /*public int GetHealth() {
        return health;
    }
    public int GetMaxHealth() {
        return ma
    }*/

    IEnumerator Pause() {
        yield return new WaitForSeconds(3f);
        gm.Death(gameObject);
        gm.Respawn();
    }
}