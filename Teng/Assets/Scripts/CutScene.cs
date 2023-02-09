using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject enemyCutscene;
    public GameObject playerCutscene;
    public GameObject cutsceneObjects;
    public GameObject timeline;
    public GameObject timelineAfter;
    public GameObject cutsceneCamera;
    // Start is called before the first frame update
    void Start()
    {
        cutsceneCamera = GameObject.Find("CutScene");
        enemyCutscene = GameObject.Find("EnemyInCutscene");
        playerCutscene = GameObject.Find("PlayerInCutscene");
        cutsceneObjects = GameObject.Find("CUTSCENES");
        timeline = GameObject.Find("Timeline");
        timelineAfter = GameObject.Find("TIMELINEAFTER");

        timelineAfter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCutsceneTransition()
    {
        timeline.gameObject.SetActive(false);
        timelineAfter.gameObject.SetActive(true);
    }
}
