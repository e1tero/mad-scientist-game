using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed = 8f;
    public int damage = 1;

    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
        StartCoroutine("WaitForDestroy");
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(this.gameObject);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            enemy.GetComponent<Animator>().SetTrigger("GetHit");
        }
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);

    }
}
