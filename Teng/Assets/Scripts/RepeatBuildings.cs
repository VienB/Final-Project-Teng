using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBuildings : MonoBehaviour

{
    private Vector3 startPos;
    private float repeatWidthBuilding;
    
    void Start()

    {
        startPos = transform.position;
        repeatWidthBuilding = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidthBuilding)
        {
            transform.position = startPos;
        }
    }
}
