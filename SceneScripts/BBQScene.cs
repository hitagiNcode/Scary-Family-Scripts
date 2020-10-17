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

    public GameObject [] bigFires;
    public GameObject sceneSis;
    public GameObject sisPlace;
    private bool holdSis = false;
    private bool startFires = false;
    public bool fireIsChanged = false;
    private bool scene2Started = false;



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
        if (fireIsChanged)
        {
            mainCharController.GoToScenePos(agentMovePos);
        }
        if (startFires)
        {
            for (int i = 0; i < bigFires.Length; i++)
            {
                bigFires[i].SetActive(true);
            }
        }
        if (fireIsChanged && mainCharController.pathReached && !mainCharController.playerIsCaught)
        {
            scene2Started = true;
            if (scene2Started)
            {
                secondCutScene.SetActive(true);
                sceneMainChar.SetActive(false);
                sceneCharacter.SetActive(true);
                HoldReleaseSis();

                scene2Started = false;
                
            }
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
        TipsManager.Instance.SendTipToPlayer("Time to mess with BBQ!");
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

    public void ActivateFires()
    {
        startFires = true;
    }
}
