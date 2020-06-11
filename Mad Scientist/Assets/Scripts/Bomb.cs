using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float power;
    public float radius;
    public LayerMask layerMask;
    Animator anim;
    //public MainCamera camera;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("BombTimer");
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(2f);

        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius, layerMask);

        foreach(Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            PlayerController player = hit.GetComponent<PlayerController>();
            Vector2 direction = hit.transform.position - transform.position;
            if (rb != null)
            {
                player.TakeDamage(1);
                rb.AddForce(direction * power);
            }
            break;
        }
        
        anim.SetTrigger("Destruction");
        
        GameObject obj = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine(obj.GetComponent<MainCamera>().Shake(.15f,.4f));
        Destroy(gameObject, 0.7f);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
