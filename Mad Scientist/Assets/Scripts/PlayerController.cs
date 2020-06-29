using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float normalSpeed;
   
    public float jumpForce;
    private float normalJumpForce;
    
    public float health = 20f;
    private float maxHealth;

    private float moveInput;
    private Rigidbody2D rb;


    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private int extraJumps;
    public int extraJumpValue;

    private Animator anim;
    private HealthBar healthBar;

    public Joystick joystick;

    public bool playerIsAlive = true;

    private void Awake()
    {
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>();
    }
    void Start()
    {

        normalSpeed = speed;
        maxHealth = health;
        normalJumpForce = jumpForce;
        
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(health);
    }

    
    void FixedUpdate()
    {
     

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);

        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }  
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);

        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
            anim.SetBool("isJumping", false);

        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        float moveVertical = joystick.Vertical;

        if (moveVertical > .5f && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if (moveVertical > .5f && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("GetHit");
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            playerIsAlive = false;
            anim.SetTrigger("Death");
            Destroy(gameObject,1f);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
        /*Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "healthBoost")
        {
            health = maxHealth;
            healthBar.SetHealth(health);
            collision.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.5f;

            Destroy(collision.gameObject, 1f);
        }
            
        if (collision.gameObject.tag == "speedBoost")
        {
            speed *= 2f;
            StartCoroutine("NormalSpeed");
            collision.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.5f;
            Destroy(collision.gameObject, 1f);
        }

        if (collision.gameObject.tag == "jumpBoost")
        {
            jumpForce *= 1.5f;
            StartCoroutine("NormalJump");
            collision.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.5f;

            Destroy(collision.gameObject, 1f);
        }
    }

    IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(5f);
        speed = normalSpeed;
    }

    IEnumerator NormalJump()
    {
        yield return new WaitForSeconds(5f);
        jumpForce = normalJumpForce;
    }

}
