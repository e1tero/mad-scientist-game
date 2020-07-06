using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
    private Transform shootPosition;
    public GameObject bullet;
    private GameObject player;
    private bool delay = false;
    public float delayTime = 1f;
    private Animator anim;

    
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        shootPosition = GameObject.FindGameObjectWithTag("shootPos").GetComponent<Transform>();
    }
    public void Shoot()
    {
        anim.SetTrigger("Shoot");
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        delay = true;
        StartCoroutine("FiringDelay");
    }

    private IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(delayTime);
        delay = false;
    }

}
