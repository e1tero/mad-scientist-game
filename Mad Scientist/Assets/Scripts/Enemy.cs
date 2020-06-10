using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    public float attackRange;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    public int health = 100;
    private Animator anim;
    public Collider2D coll;
    public int damage = 10;
    public bool playerAlive = true;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log("playerAlive = " + playerAlive);
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer < agroRange && playerAlive == true)
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
        
        else if (distanceToPlayer > agroRange || playerAlive == false)
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
        health -= damage;
        anim.SetBool("isAttacking", false);
        anim.SetBool("isElectring", true);
        rb2d.velocity = new Vector2(0, 0);
        Destroy(gameObject, 0.6f);
    }

}
