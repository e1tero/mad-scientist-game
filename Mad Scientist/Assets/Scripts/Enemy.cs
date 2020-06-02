using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    public int health = 100;
    private Animator anim;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
       
    
    }

    void ChasePlayer()
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);

        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health = -damage;

        if (health <= 0)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isElectring", true);
            rb2d.velocity = new Vector2(0, 0);
            Destroy(gameObject, 0.6f);
        }
       
    }

}
