using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] spawningobstaclePrefab;
    private PlayerController playerController;
    private Buttons buttons;
    public float spawnDelay = 5.0f;
    private float spawnPosZ = 30.0f;
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        buttons = GameObject.Find("BUTTONS").GetComponent<Buttons>();
        InvokeRepeating("spawningObstacle", spawnDelay, Random.Range(1.5f, 2.0f));
    }

    
    void Update()
    {
        
    }
    void spawningObstacle()
    {
        if(playerController.gameOver == false && buttons.gamePause == false)
        {
            
            int obstacleIndex = Random.Range(0, spawningobstaclePrefab.Length);
            //Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
            if (obstacleIndex == 0)
            {
                Vector3 spawnPos = new Vector3(0, 0.34f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[0], spawnPos, spawningobstaclePrefab[0].transform.rotation);
            }
            else if (obstacleIndex == 1)
            {
                Vector3 spawnPos = new Vector3(0, 0.38f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[1], spawnPos, spawningobstaclePrefab[1].transform.rotation);
            }
            else if (obstacleIndex == 2)
            {
                Vector3 spawnPos = new Vector3(0, 0.31f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[2], spawnPos, spawningobstaclePrefab[2].transform.rotation);
            }
            else if (obstacleIndex == 3)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[3], spawnPos, spawningobstaclePrefab[3].transform.rotation);
            }
            else if (obstacleIndex == 4)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[4], spawnPos, spawningobstaclePrefab[4].transform.rotation);
            }
            else if (obstacleIndex == 5)
            {
                Vector3 spawnPos = new Vector3(0, 0.37f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[5], spawnPos, spawningobstaclePrefab[5].transform.rotation);
            }
            else if (obstacleIndex == 6)
            {
                Vector3 spawnPos = new Vector3(0, -0.07f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[6], spawnPos, spawningobstaclePrefab[6].transform.rotation);
            }
            else if (obstacleIndex == 7)
            {
                Vector3 spawnPos = new Vector3(0, 0.14f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[7], spawnPos, spawningobstaclePrefab[7].transform.rotation);
            }
            else if (obstacleIndex == 8)
            {
                Vector3 spawnPos = new Vector3(0.08f, 0.03f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[8], spawnPos, spawningobstaclePrefab[8].transform.rotation);
            }
            else if (obstacleIndex == 9)
            {
                Vector3 spawnPos = new Vector3(0, -0.01f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[9], spawnPos, spawningobstaclePrefab[9].transform.rotation);
            }
            else if (obstacleIndex == 10)
            {
                Vector3 spawnPos = new Vector3(0, 0.14f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[10], spawnPos, spawningobstaclePrefab[10].transform.rotation);
            }
            else if (obstacleIndex == 11)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[11], spawnPos, spawningobstaclePrefab[11].transform.rotation);
            }
            else if (obstacleIndex == 12)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[12], spawnPos, spawningobstaclePrefab[12].transform.rotation);
            }
            else if (obstacleIndex == 13)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[13], spawnPos, spawningobstaclePrefab[13].transform.rotation);
            }
            else if (obstacleIndex == 14)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[14], spawnPos, spawningobstaclePrefab[14].transform.rotation);
            }
            else if (obstacleIndex == 15)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[15], spawnPos, spawningobstaclePrefab[15].transform.rotation);
            }
            else if (obstacleIndex == 16)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[16], spawnPos, spawningobstaclePrefab[16].transform.rotation);
            }
            else if (obstacleIndex == 17)
            {
                Vector3 spawnPos = new Vector3(0, 0.2f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[17], spawnPos, spawningobstaclePrefab[17].transform.rotation);
            }
            else if (obstacleIndex == 18)
            {
                Vector3 spawnPos = new Vector3(0, 0, spawnPosZ);
                Instantiate(spawningobstaclePrefab[18], spawnPos, spawningobstaclePrefab[18].transform.rotation);
            }
            else if (obstacleIndex == 19)
            {
                Vector3 spawnPos = new Vector3(0, 0.1f, spawnPosZ);
                Instantiate(spawningobstaclePrefab[19], spawnPos, spawningobstaclePrefab[19].transform.rotation);
            }

        }
    }
}
