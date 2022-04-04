using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetHealth : MonoBehaviour
{
    public int targetHealthVal;
    public int targetHealth;
    private GameObject waveSpawner;
    // Start is called before the first frame update
    void Start()
    {
        targetHealth = targetHealthVal;
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHealth <= 0 && waveSpawner.GetComponent<WaveSpawner>().isDone == false)
        {
            Debug.Log("Lost Game");
            SceneManager.LoadScene("Retry");
        }else if(targetHealth <= 0 && waveSpawner.GetComponent<WaveSpawner>().isDone)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
    public void TargetTakeDamage(int damage)
    {
        targetHealth -= damage;
    }
}
