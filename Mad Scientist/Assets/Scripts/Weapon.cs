using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            bullet.SetActive(true);
        }
        
        else bullet.SetActive(false);
    }
}
