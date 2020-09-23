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

    
    


    // Start is called before the first frame update
    void Start()
    {
        SetGameObjects();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetGameObjects()
    {
        trap.SetActive(true);
        newspaper.SetActive(true);
        firstCutScene.SetActive(true);
        secondCutScene.SetActive(false);
        sceneCharacter.transform.position = agentStartPoint;
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
}
