using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator npcAnim;
    public float timer;
    public float yPos = 1.0f;
    public float zPos = -2.5f;
    public float zPosNearPlayer = -1.2f;

    public Vector3 comparisonOffset;
    public Vector3 nearPlayer;

    public Transform target;
    public Vector3 offset;
    private float y;
    public float speedFollow = 5f;


    void Start()
    {
        npcAnim = GameObject.Find("Enemy").GetComponent<Animator>();
        timer = 5.0f;
        nearPlayer = new Vector3(0, yPos, zPosNearPlayer);
        comparisonOffset = new Vector3(0, yPos, zPos);
        offset = comparisonOffset;
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

        while (offset != comparisonOffset)
        {
            timer -= 1 * Time.deltaTime;
            Debug.Log(timer);

            if (timer < 0.3f)
            {
                npcAnim.Play("Rolling");
            }

            if (timer < 0)
            {
                offset = comparisonOffset;
                timer = 5.0f;
            }
            break;
        }
    }
}
