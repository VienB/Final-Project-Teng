using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float y;
    public float speedFollow = 5f;


    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = target.position + offset;
        RaycastHit hit;
        if (Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * speedFollow);
        else y = Mathf.Lerp(y, target.position.y, Time.deltaTime * speedFollow);
        newPosition.y = offset.y + y;
        transform.position = newPosition;

    }
}