using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public float workingTime;
    public float reloadTime;
    private UIButtonInfo buttonShoot;


     private void Start()
     {
        buttonShoot = GameObject.FindGameObjectWithTag("shootControlHUD").GetComponent<UIButtonInfo>();
     }
    void Update()
    {
        if (buttonShoot.isDown)
        {
            bullet.SetActive(true);
            workingTime -= Time.deltaTime;
        }
        else
        {
            bullet.SetActive(false);
            workingTime += Time.deltaTime * 0.5f;

            if (workingTime > 4)
                workingTime = 4;
        }

        
        if (workingTime <= 0)
        {
            bullet.SetActive(false);
        }
    }
}
