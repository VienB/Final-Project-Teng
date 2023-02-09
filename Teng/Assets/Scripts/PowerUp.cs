using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject coinDetector;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        coinDetector = GameObject.FindGameObjectWithTag("CoinDetector");
        coinDetector.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shark")
        {
            playerController.forwardSpeed += 10.0f;
            Debug.Log("Shark");
        }
        if(other.gameObject.tag == "Pig")
        {
            Debug.Log("Pig");
        }
        if(other.gameObject.tag == "Kite")
        {
            playerController.jumpForce = 15.0f;
            StartCoroutine(KiteDuration());
            Debug.Log("Kite");
        }
    }
    IEnumerator KiteDuration()
    {
        yield return new WaitForSeconds(8.0f);
        playerController.jumpForce = 10.0f;
        if (gameObject.tag == "Kite")
        {
            Destroy(gameObject);
        }
    }
}
