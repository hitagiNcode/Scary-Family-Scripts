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
    public Vector3 placedNewspaperSpot;
    public DoubleDoor m_door;
    public GameObject trapCharPlace;

    
    public GameObject particleNewspaper;
    public GameObject particleTrap;

    private bool trapIsReady = false;
    private bool paperIsReady = false;
    private bool bellrang = false;

    private bool holdNewspaper = true;
    private bool holdTrap = false;

    
    


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
        if (holdTrap)
        {
            trap.transform.position = trapCharPlace.transform.position;
            trap.transform.rotation = trapCharPlace.transform.rotation;
        }
        if (bellrang)
        {
            mainCharController.GoToScenePos(agentMovePos.transform);
        }
        if (bellrang && mainCharController.pathReached && !mainCharController.playerIsCaught)
        {
            secondCutScene.SetActive(true);
            sceneMainChar.SetActive(false);
            sceneCharacter.SetActive(true);
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
        
        particleNewspaper.SetActive(false);
        newspaper.transform.gameObject.tag = "Untagged";
        newspaper.transform.parent = null;
        newspaper.transform.position = placedNewspaperSpot;
        newspaper.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void PlacedTrap()
    {
        trapIsReady = true;
        particleTrap.SetActive(false);
        trap.transform.gameObject.tag = "Untagged";
        trap.transform.parent = null;
        trap.transform.position = trapSpot;
        trap.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void RingBell()
    {
        if (paperIsReady && trapIsReady)
        {
            bellrang = true;

        }
        
    }

    public void OpenDoor()
    {
        m_door.ScriptDoorOpen();
    }

    public void PutTrap()
    {
        holdTrap = true;
        trap.GetComponent<Animator>().SetBool("CloseTrap", true);
    }

    public void CompleteLevel()
    {
       LevelCompletePanel.Instance.completeLevel();
       LevelCompletePanel.Instance.GoldEarnedAmount(95);
       Time.timeScale = 0f;
    }
}
