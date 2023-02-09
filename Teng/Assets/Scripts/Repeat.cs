using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatRoad = 24f;
    
    

    void Start()
    {
        startPos = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z- repeatRoad)
        {
            transform.position = startPos;
        }
      
    }
}
