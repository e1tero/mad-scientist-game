using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner1 : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject[] boost;

    public Transform[] boostPoints;
    public Transform[] bombPoints;

    public float bombSpawnTime = 2f;
    public float boostSpawnTime = 6f;

    void Start()
    {
        InvokeRepeating("SpawnBomb", bombSpawnTime, bombSpawnTime);
        InvokeRepeating("SpawnBoost", boostSpawnTime, boostSpawnTime);
    }

    void SpawnBomb()
    {
        int position = Random.Range(0, 4);
        Instantiate(bombPrefab, bombPoints[position].transform.position, Quaternion.identity);
    }

    void SpawnBoost()
    {
        int position = Random.Range(0, 3);
        int property = Random.Range(0, 3);
        Instantiate(boost[property], boostPoints[position].transform.position, Quaternion.identity);
    }
}
