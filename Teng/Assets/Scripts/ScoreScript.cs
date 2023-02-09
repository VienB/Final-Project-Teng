using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;

    private int scoreBoundary;
    private PlayerController playerController;
    
    Text score;
    



    // Start is called before the first frame update
    void Start()
    {
        scoreBoundary = 500;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameOver == false)
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue;
            if(scoreValue == scoreBoundary)
            {
                playerController.forwardSpeed += 0.5f;
                scoreBoundary += 500;
            }
        }
        else if(playerController.gameOver == true)
        {
            score.text = "Your Final Score: " + scoreValue;
        }
    }
    public void ResettingScore()
    {
        scoreValue = 0;
    }
}
