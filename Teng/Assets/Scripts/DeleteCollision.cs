using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollision : MonoBehaviour
{
    private float rotateCoins = 2.0f;
    public GameObject coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateCoins);   
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CoinBoard.coinCollection += 1;
            Destroy(gameObject);

        }
    }
}
