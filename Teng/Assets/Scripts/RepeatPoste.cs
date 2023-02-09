using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatPoste : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatRoad=50;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //repeatRoad = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatRoad)
        {
            transform.position = startPos;
        }
    }
}
