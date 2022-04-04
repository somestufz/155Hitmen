using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAI : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    private GameObject chosenTarget;
    public float enemySpeed;
    public Vector2[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
        transform.position = spawnLocations[Random.Range(1, spawnLocations.Length)];
        chosenTarget = target;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, chosenTarget.transform.position, enemySpeed * Time.deltaTime);
        EnemyRotation();
    }
    void EnemyRotation()
    {
        Vector2 direction = new Vector2(chosenTarget.transform.position.x - transform.position.x, chosenTarget.transform.position.y - transform.position.y);
        transform.up = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyTriggered");
    }
}
