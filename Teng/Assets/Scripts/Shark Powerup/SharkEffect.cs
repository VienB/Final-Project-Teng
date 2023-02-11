using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkEffect : MonoBehaviour
{
    private BoxCollider obstacleCollider;
    private OnCollision onCollisionScript;

    private void Start()
    {
        obstacleCollider = GetComponent<BoxCollider>();
        onCollisionScript = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<OnCollision>();
    }

    private void Update()
    {
        if (onCollisionScript.sharkPowerUp == true)
        {
            obstacleCollider.isTrigger = true;
        }
        else if (onCollisionScript.sharkPowerUp == false)
        {
            obstacleCollider.isTrigger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
