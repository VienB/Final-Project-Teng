using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coin coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coin.playerTransform.position, coin.moveSpeed * Time.deltaTime);
    }
}
