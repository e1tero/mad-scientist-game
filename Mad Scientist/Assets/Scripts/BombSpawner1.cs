using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner1 : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform[] points;

    void Start()
    {
        InvokeRepeating("SpawnBomb", 3f, 3f);
    }

    void SpawnBomb()
    {
        int position = Random.Range(1, 3);
        Instantiate(bombPrefab, points[position].transform.position, Quaternion.identity);
    }
}
