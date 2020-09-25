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
    public Vector3 newspaperSpot;
    public Vector3 trapSpot;

    private bool trapIsReady = false;
    private bool paperIsReady = false;
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

        if (paperIsReady&&trapIsReady)
        {


        }
        
    }

    private void SetGameObjects()
    {
        trap.SetActive(true);
        newspaper.SetActive(true);
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

    public void completeLevel()
    {
        LevelCompletePanel.Instance.completeLevel();
        LevelCompletePanel.Instance.GoldEarnedAmount(100);
    }

    public void ReleaseNewsPaper()
    {
        holdNewspaper = !holdNewspaper;
        newspaper.transform.position = newspaperSpot;
        newspaper.transform.rotation = Quaternion.Euler(0, 18, 0);
    }

    public void PlacedNewspaper()
    {
        paperIsReady = true;
        newspaper.transform.gameObject.tag = "Untagged";
    }
    public void PlacedTrap()
    {
        trapIsReady = true;
        trap.transform.gameObject.tag = "Untagged";
        trap.transform.parent = null;
        trap.transform.position = trapSpot;
        trap.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
