using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    public float attackRange;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;
    Transform player;

    public float health = 100;
    private Animator anim;
    public int damage = 10;
    private bool facingRight = true;

    public HealthBar healthBar;
    public GameObject healthBarObject;
    public GameObject hitBox;
    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Start()
    {
        healthBar.SetMaxHealth((int)health);
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer < agroRange)
        {
            if (distanceToPlayer > attackRange)
            {
                ChasePlayer();
            }
            
            else if (distanceToPlayer <= attackRange)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
            }
        }
        
        else if (distanceToPlayer > agroRange)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }

    void ChasePlayer()
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);

        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            if (facingRight)
            {
                Flip();
            }

        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            if (!facingRight)
            {
                Flip();
            }
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetBool("isAttacking", false);
        anim.SetTrigger("GetHit");
        healthBar.SetHealth(health);
        
        if (health <= 0)
        {
            hitBox.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            healthBarObject.SetActive(false);
            anim.SetTrigger("Death");
            Destroy(gameObject, 1f);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }

}
