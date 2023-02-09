using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawningobstaclePrefab;
    private GameObject player;
    private PlayerController playerController;
    private Buttons buttons;
    public float spawnDelay = 5.0f;

    private float manilaSpawnStart = 90.0f;
    private float sanJuanicoSpawnStart = 140.0f;
    private float viganSpawnStart = 70.0f;


    private float manilaSpawn = 165.5f;
    private float sanJuanicoSpawn = 210.0f;
    private float viganSpawn = 141.95f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GettingComponents()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        int obstacleIndex = Random.Range(0, spawningobstaclePrefab.Length);
        if (obstacleIndex == 0)
        {
            Vector3 spawnPos = new Vector3(-14.1f, 19.25f, (player.transform.position.z + manilaSpawnStart));
            Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
        }
        if (obstacleIndex == 1)
        {
            Vector3 spawnPos = new Vector3(0.0f, -0.66f, (player.transform.position.z + sanJuanicoSpawnStart));
            Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
        }
        if (obstacleIndex == 2)
        {
            Vector3 spawnPos = new Vector3(0.0f, -0.624f, (player.transform.position.z + viganSpawnStart));
            Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
        }
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        buttons = GameObject.Find("BUTTONS").GetComponent<Buttons>();
    }
    public void spawningObstacle()
    {
        if (playerController.gameOver == false && buttons.gamePause == false)
        {
            int obstacleIndex = Random.Range(0, spawningobstaclePrefab.Length);
            if(obstacleIndex == 0)
            {
                Vector3 spawnPos = new Vector3(-14.1f, 19.25f, (player.transform.position.z + manilaSpawn));
                Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
            }
            if(obstacleIndex == 1)
            {
                Vector3 spawnPos = new Vector3(0.0f, -0.66f, (player.transform.position.z + sanJuanicoSpawn));
                Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
            }
            if (obstacleIndex == 2)
            {
                Vector3 spawnPos = new Vector3(0.0f, -0.624f, (player.transform.position.z + viganSpawn));
                Instantiate(spawningobstaclePrefab[obstacleIndex], spawnPos, spawningobstaclePrefab[obstacleIndex].transform.rotation);
            }
        }
    }
}
