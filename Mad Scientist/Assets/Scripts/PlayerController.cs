using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float health = 100f;
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

    public bool playerIsAlive = true;

    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
     

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);

        moveInput = Input.GetAxis("Horizontal");
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


        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("GetHit");
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


}
