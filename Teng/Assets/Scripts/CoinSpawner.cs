using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    private float spawnPosZ = 30.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("leftLane", Random.Range(0.0f, 1.5f), Random.Range(1.5f, 5.0f));
        InvokeRepeating("midLane", Random.Range(0.0f, 1.5f), Random.Range(1.5f, 5.0f));
        InvokeRepeating("rightLane", Random.Range(0.0f, 1.5f), Random.Range(1.5f, 5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void leftLane()
    {
        
        Vector3 leftLane = new Vector3(-3.0f, 0.65f, spawnPosZ);
        Instantiate(coinPrefab, leftLane, coinPrefab.transform.rotation);


    }
    void midLane()
    {
        
        Vector3 midLane = new Vector3(0.0f, 0.65f, spawnPosZ);
        Instantiate(coinPrefab, midLane, coinPrefab.transform.rotation);
    }
    void rightLane()
    {
        
        Vector3 rightLane = new Vector3(3.0f, 0.65f, spawnPosZ);
        Instantiate(coinPrefab, rightLane, coinPrefab.transform.rotation);

    }



}

