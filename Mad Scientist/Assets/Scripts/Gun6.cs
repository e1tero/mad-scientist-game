using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun6 : MonoBehaviour
{
    private Transform firstShootPosition;
    private Transform secondShootPosition;
    public GameObject bullet;
    private GameObject player;
    private bool delay = false;
    public float delayTime = 1f;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        firstShootPosition = GameObject.FindGameObjectWithTag("firstShootPos").GetComponent<Transform>();
        secondShootPosition = GameObject.FindGameObjectWithTag("secondShootPos").GetComponent<Transform>();
    }
    public void Shoot()
    {
        anim.SetTrigger("Shoot");
        Instantiate(bullet, firstShootPosition.position, firstShootPosition.rotation);
        Instantiate(bullet, secondShootPosition.position, secondShootPosition.rotation);
        delay = true;
        StartCoroutine("FiringDelay");
    }

    private IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(delayTime);
        delay = false;
    }

}
