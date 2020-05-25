using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    public AnimationClip clip;

    public void Start()
    {
       
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health = -damage;

        if (health <= 0)
        {
            anim.SetBool("isElectring", true);
            Destroy(gameObject, clip.length);
        }
       
    }

}
