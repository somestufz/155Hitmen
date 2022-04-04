using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealthVal;
    public int enemyHealth;
    public int enemyType;
    public GameObject[] deadEnemies;
    public float enemyBaseAttackCooldownVal;
    public float enemyBaseAttackCooldown;
    public int enemyMeleeDamage;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyHealthVal;
    }

    // Update is called once per frame
    void Update()
    {
        enemyBaseAttackCooldown -= Time.deltaTime;
       if(enemyHealth <= 0)
        {
            if (GameObject.FindGameObjectWithTag("WaveSpawn").GetComponent<WaveSpawner>().enemiesIn == 1)
            {
                GameObject.FindGameObjectWithTag("WaveSpawn").GetComponent<WaveSpawner>().waveCooldown = GameObject.FindGameObjectWithTag("WaveSpawn").GetComponent<WaveSpawner>().waveCooldownVal;
            }
            GameObject.FindGameObjectWithTag("WaveSpawn").GetComponent<WaveSpawner>().enemiesIn--;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().tableCooldown++;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().hitmenLeft--;
            if(enemyType == 1)
            {
                Instantiate(deadEnemies[0],transform);
            }
            if (enemyType == 2)
            {
                Instantiate(deadEnemies[1],transform);
            }
            transform.DetachChildren();
            Destroy(gameObject);
        } 
    }
    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<TargetHealth>().TargetTakeDamage(enemyMeleeDamage);
            enemyBaseAttackCooldown = enemyBaseAttackCooldownVal;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target") && enemyBaseAttackCooldown <= 0)
        {
            collision.gameObject.GetComponent<TargetHealth>().TargetTakeDamage(enemyMeleeDamage);
            enemyBaseAttackCooldown = enemyBaseAttackCooldownVal;
        }
        else if (collision.gameObject.CompareTag("Table") && enemyBaseAttackCooldown <= 0)
        {
            collision.gameObject.GetComponent<TableHealth>().LoseOneHealth();
            enemyBaseAttackCooldown = enemyBaseAttackCooldownVal;
        }
    }
}
