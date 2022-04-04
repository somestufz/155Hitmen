using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject targetObject;
    private GameObject waveSpawnerObject;
    public TextMeshProUGUI targetHealthText;
    public TextMeshProUGUI tableCooldownText;
    public TextMeshProUGUI hitmenLeft;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        targetObject = GameObject.FindGameObjectWithTag("Target");
        waveSpawnerObject = GameObject.FindGameObjectWithTag("WaveSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        UIStuff();
    }
    void UIStuff()
    {
        targetHealthText.text = "VIP's Health : " + targetObject.GetComponent<TargetHealth>().targetHealth;
        
        tableCooldownText.text = playerObject.GetComponent<Movement>().tableCooldown + "";
        if(waveSpawnerObject.GetComponent<WaveSpawner>().isDone == false)
        {
            hitmenLeft.text = playerObject.GetComponent<Movement>().hitmenLeft + " LEFT";
        }else if (waveSpawnerObject.GetComponent<WaveSpawner>().isDone)
        {
            hitmenLeft.text = "Kill the VIP";
        }
        
    }
}
