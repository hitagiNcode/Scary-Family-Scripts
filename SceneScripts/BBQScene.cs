using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQScene : MonoBehaviour
{
    public Vector3 agentStartPoint;
    public GameObject sceneMainChar;
    public GameObject sceneCharacter;
    public GameObject firstCutScene;
    public GameObject secondCutScene;
    public Transform agentMovePos;
    private NpcControl mainCharController;

    //Special to scene
    
    public GameObject sceneSis;
    public GameObject sisPlace;
    private bool holdSis = false;
    public bool fireIsChanged = false;



    // Start is called before the first frame update
    void Start()
    {
        SetGameObjects();

    }

    // Update is called once per frame
    void Update()
    {
        if (holdSis)
        {
            sceneSis.transform.position = sisPlace.transform.position;
            sceneSis.transform.rotation = sisPlace.transform.rotation;
        }
    }

    private void SetGameObjects()
    {

        firstCutScene.SetActive(true);
        sceneCharacter.SetActive(true);
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

    public void CompleteLevel()
    {
        LevelCompletePanel.Instance.completeLevel();
        LevelCompletePanel.Instance.GoldEarnedAmount(100);
        Time.timeScale = 0f;
    }

    public void HoldReleaseSis()
    {
        holdSis = !holdSis;
    }
}
