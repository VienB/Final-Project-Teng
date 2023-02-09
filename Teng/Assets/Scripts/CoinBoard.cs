using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBoard : MonoBehaviour
{
    private PlayerController playerController;
    public static int coinCollection = 0;
    Text coin;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        coin = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false)
        {
            coin.text = ": " + coinCollection;
        }
        else if (playerController.gameOver == true)
        {
            coin.text = "Your coins: " + coinCollection;
        }
    }
    public void ResettingCoin()
    {
        coinCollection = 0;
    }
}
