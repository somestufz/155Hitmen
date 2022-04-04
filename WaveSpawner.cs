using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyMelee1;
    public GameObject enemtRange1;
    public int enemiesIn;
    public int enemiesToSpawn;
    public float waveCooldown;
    public float waveCooldownVal;
    public int waveNum;
    public int[] waveEnemieNums;
    public bool isDone;
    // Start is called before the first frame update
    void Start()
    {
        waveNum = 0;
        enemiesToSpawn = waveEnemieNums[waveNum];
        SpawnWave();
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        waveCooldown -= Time.deltaTime;
        if(enemiesIn <= 0 && waveCooldown <= 0 && waveNum < 21)
        {
            enemiesToSpawn = waveEnemieNums[waveNum];
            SpawnWave();
        }
        if(waveNum == 20 && enemiesIn <= 0)
        {
            isDone = true;
        }
    }

    void SpawnWave()
    {
        waveNum++;
        Debug.Log("WaveSpawned");
        while(enemiesIn < enemiesToSpawn)
        {
            Debug.Log("PO");
            if(Random.Range(1,3) == 1)
            {
                Instantiate(enemyMelee1);
            }
            else
            {
                Instantiate(enemtRange1);
            }
            enemiesIn++;
            
        }
       
    }
}
