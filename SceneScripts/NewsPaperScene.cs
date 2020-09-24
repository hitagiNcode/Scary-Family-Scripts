using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperScene : MonoBehaviour
{
    public Vector3 agentStartPoint;
    public GameObject sceneMainChar;
    public GameObject sceneCharacter;
    public GameObject firstCutScene;
    public GameObject secondCutScene;
    public Transform agentMovePos;
    private NpcControl mainCharController;

    //Special to scene
    public GameObject trap;
    public GameObject newspaper;
    public Transform oldmanHandplace;

    private bool holdNewspaper = true;

    
    


    // Start is called before the first frame update
    void Start()
    {
        SetGameObjects();

    }

    // Update is called once per frame
    void Update()
    {
        if (holdNewspaper)
        {
            newspaper.transform.position = oldmanHandplace.transform.position;
            newspaper.transform.rotation = oldmanHandplace.transform.rotation;
        }
        
    }

    private void SetGameObjects()
    {
        trap.SetActive(true);
        newspaper.SetActive(true);
        firstCutScene.SetActive(true);
        secondCutScene.SetActive(false);
        
        sceneMainChar.SetActive(false);
        mainCharController = sceneMainChar.GetComponent<NpcControl>();
        mainCharController.isCoroutineStarted = false;
    }

    public void DeActivateAfterScene()
    {
        sceneCharacter.SetActive(false);
        sceneMainChar.transform.position = agentStartPoint;
        sceneMainChar.SetActive(true);
    }

    public void completeLevel()
    {
        LevelCompletePanel.Instance.completeLevel();
        LevelCompletePanel.Instance.GoldEarnedAmount(100);
    }

    public void ReleaseNewsPaper()
    {
        holdNewspaper = !holdNewspaper;
    }
}
