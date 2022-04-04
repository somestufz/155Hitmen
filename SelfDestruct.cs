using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destruct;
    public float destructVal;
    // Start is called before the first frame update
    void Start()
    {
        destructVal = 4;
        destruct = destructVal;
    }

    // Update is called once per frame
    void Update()
    {
        destruct -= Time.deltaTime;
        if(destruct <= 0)
        {
            Destroy(gameObject);
        }
    }
}
