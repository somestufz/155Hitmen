using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForward : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);
        if(transform.position.x > 200 || transform.position.x < -200 || transform.position.y > 200|| transform.position.y < -200)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Table"))
        {
            collision.gameObject.GetComponent<TableHealth>().LoseOneHealth();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit");
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(bulletDamage);
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<TargetHealth>().TargetTakeDamage(1);
            Destroy(gameObject);
        }
    }
}
