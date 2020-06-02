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
    
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            bullet.SetActive(true);
            workingTime -= Time.deltaTime;
        }

        else
        {
            bullet.SetActive(false);
            if (workingTime < reloadTime)
            {
                workingTime += Time.deltaTime * 0.5f;
            }
        }

        if (workingTime <= 0)
        {
            bullet.SetActive(false);
        }
    }


}
