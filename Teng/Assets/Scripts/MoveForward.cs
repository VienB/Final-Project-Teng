using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveForward : MonoBehaviour
{
    public float scoreBoundary = 2000.0f;
    public float speed = 5.0f;
    private PlayerController playerControllerScript;
    private Buttons buttons;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        buttons = GameObject.Find("BUTTONS").GetComponent<Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false && buttons.gamePause == false)
        {
            ScoreScript.scoreValue += 1;
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        if (ScoreScript.scoreValue > scoreBoundary)
        {
            speed += 0.01f;
            scoreBoundary += 2000.0f;
        }
    }
}
