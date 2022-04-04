using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealthVal;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerHealthVal;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            Debug.Log("Player Lost");
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        //playerHealth -= damage;
    }
}
