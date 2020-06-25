﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public Transform shootPosition;
    public GameObject bullet;
    private bool delay = false;
    public float delayTime = 1f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && delay == false)
        {
            anim.SetTrigger("Shoot");
            Instantiate(bullet, shootPosition.position, shootPosition.rotation);
            delay = true;
            StartCoroutine("FiringDelay");
        }
    }

    private IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(delayTime);
        delay = false;
    }
}