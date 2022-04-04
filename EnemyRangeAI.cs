using UnityEngine;

public class EnemyRangeAI : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    private GameObject chosenTarget;
    public GameObject focusPoint;
    public GameObject enemyBullet;
    public float enemySpeed;
    public float enemyRangeFrom;
    public float enemyCooldownVal;
    public float enemyCooldown;
    public Vector2[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        enemyCooldown = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");
        transform.position = spawnLocations[Random.Range(1, spawnLocations.Length)];
        transform.position = transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2),0);
        
        chosenTarget = target;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCooldown -= Time.deltaTime;
        if (Vector2.Distance(transform.position,chosenTarget.transform.position) > enemyRangeFrom)
        {
            transform.position = Vector2.MoveTowards(transform.position, chosenTarget.transform.position, enemySpeed * Time.deltaTime);
        }
        if (enemyCooldown <= 0)
        {
            EnemyShoot();
            enemyCooldown = enemyCooldownVal;
        }
        EnemyRotation();
    }
    void EnemyRotation()
    {
        Vector2 direction = new Vector2(chosenTarget.transform.position.x - transform.position.x,chosenTarget.transform.position.y - transform.position.y);
        transform.up = direction;
    }

    void EnemyShoot()
    {
        Instantiate(enemyBullet, focusPoint.transform);
        focusPoint.transform.DetachChildren();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyTriggered");
    }
}
