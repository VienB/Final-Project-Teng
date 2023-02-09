using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject coinDetector;
    private PlayerController characterController;
    private CapsuleCollider playerCapsuleCollider;

    public bool sharkPowerUp = false;

    private void Start()
    {
        playerCapsuleCollider = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<CapsuleCollider>();
        coinDetector = GameObject.FindGameObjectWithTag("CoinDetector");
        coinDetector.SetActive(false);
    }
    void Update()
    {
        characterController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            return;
        characterController.CharacterColliding(collision.collider);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kite"))
        {
            Destroy(other.transform.GetChild(0).gameObject);
            characterController.forwardSpeed += 5.0f;
            characterController.jumpForce = 15.0f;
            StartCoroutine(KiteDuration());
        }
        else if (other.CompareTag("Shark"))
        {
            playerCapsuleCollider.isTrigger = true;
            Destroy(other.transform.GetChild(0).gameObject);
            characterController.forwardSpeed += 10.0f;
            StartCoroutine(SharkDuration());
        }
        else if (other.CompareTag("Pig"))
        {
            coinDetector.SetActive(true);
            StartCoroutine(PigDuration());
            Destroy(other.transform.GetChild(0).gameObject);
            Debug.Log("Pig");
        }
    }

    public IEnumerator KiteDuration()
    {
        yield return new WaitForSeconds(8);
        characterController.jumpForce = 10.0f;
        characterController.forwardSpeed -= 5.0f;
    }
    public IEnumerator SharkDuration()
    {
        yield return new WaitForSeconds(8);
        characterController.forwardSpeed -= 10.0f;
        playerCapsuleCollider.isTrigger = false;
    }

    public IEnumerator PigDuration()
    {
        yield return new WaitForSeconds(8);
        coinDetector.SetActive(false);
    }
}