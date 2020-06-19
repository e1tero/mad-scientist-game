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

    public int health = 100;
    private Animator anim;
    public int damage = 10;
    private bool facingRight = true;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetBool("isAttacking", false);
        anim.SetBool("isElectring", true);
        rb2d.velocity = new Vector2(0, 0);
        Destroy(gameObject, 0.6f);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }

}
