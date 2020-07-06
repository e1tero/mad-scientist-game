using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesScript : MonoBehaviour
{
    public GameObject firstEnemy;
    public GameObject secondEnemy;

    public Transform[] spawnPositions;

    public GameObject[] wavesText;

    public BombSpawner1 bombSpawner;

    public int numberOfWave = 1;

    public int nextWaveTime = 20;

    public int spawnFrequency;


    public void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnFrequency, spawnFrequency);
        InvokeRepeating("WaveTime", nextWaveTime, nextWaveTime);
    }

    public void Update()
    {
        Debug.Log(numberOfWave + " " + spawnFrequency + " " + nextWaveTime);
    }


    public void SpawnEnemy()
    {
        if (numberOfWave == 1)
        {
            wavesText[0].SetActive(true);
            spawnFrequency = 8;
            bombSpawner.bombSpawnTime = 6;
            Instantiate(firstEnemy, spawnPositions[1].transform.position, Quaternion.identity);
        }

        else if (numberOfWave == 2)
        {
            wavesText[1].SetActive(true);
            spawnFrequency = 7;
            bombSpawner.bombSpawnTime = 5;
            int position = Random.Range(0, 1);
            Instantiate(firstEnemy, spawnPositions[0].transform.position, Quaternion.identity);
            Instantiate(firstEnemy, spawnPositions[1].transform.position, Quaternion.identity);
        }

        else if (numberOfWave == 3)
        {
            wavesText[3].SetActive(true);
            spawnFrequency = 7;
            bombSpawner.bombSpawnTime = 3;
            int position = Random.Range(0, 1);
            Instantiate(secondEnemy, spawnPositions[1].transform.position, Quaternion.identity);
            Instantiate(firstEnemy, spawnPositions[0].transform.position, Quaternion.identity);
        }

        else if (numberOfWave == 4)
        {
            wavesText[4].SetActive(true);
            spawnFrequency = 5;
            bombSpawner.bombSpawnTime = 4;
            int position = Random.Range(0, 1);
            Instantiate(secondEnemy, spawnPositions[0].transform.position, Quaternion.identity);
            Instantiate(firstEnemy, spawnPositions[1].transform.position, Quaternion.identity);
        }

        else if (numberOfWave == 5)
        {
            wavesText[5].SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void WaveTime()
    {
        numberOfWave++;
    }
}
