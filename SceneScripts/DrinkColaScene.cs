using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkColaScene : MonoBehaviour
{
    public Vector3 agentStartPoint;
    public GameObject vomitSystem;
    public GameObject sceneMainChar;
    public GameObject scenePos;
    public GameObject secondCutScene;
    public GameObject cola;
    public GameObject sceneDrinkCola;
    public GameObject SceneCharacter;
    public Transform oldManHand;


    [HideInInspector]
    public bool drinkIsReady = false;
    private bool holdCola = false;
    private Vector3 colaStartPos;
    private Quaternion colastartRot;
    private NpcControl mainCharController;

    // Start is called before the first frame update
    void Start()
    {
        vomitSystem.SetActive(false);
        secondCutScene.SetActive(false);
        sceneMainChar.SetActive(false);
        ActivateSceneObjs();
        colaStartPos = cola.transform.position;
        colastartRot = cola.transform.rotation;
        mainCharController = sceneMainChar.GetComponent<NpcControl>();
        mainCharController.isCoroutineStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdCola)
        {
            cola.transform.position = oldManHand.transform.position;
            cola.transform.rotation = oldManHand.transform.rotation;
        }
        if (drinkIsReady)
        {
            mainCharController.GoToScenePos(scenePos.transform);
        }
        if (drinkIsReady && mainCharController.pathReached)
        {
            secondCutScene.SetActive(true);
            sceneMainChar.SetActive(false);
        }
        
    }

    public void HoldColaHand()
    {
        holdCola = true;
    }
    public void ReleaseCola()
    {
        holdCola = false;
        cola.transform.position = colaStartPos;
        cola.transform.rotation = colastartRot;
    }

    public void ActivateSceneObjs()
    {
        cola.SetActive(true);
        sceneDrinkCola.SetActive(true);
        SceneCharacter.SetActive(true);
    }

    public void DeActivateObjs()
    {
        SceneCharacter.SetActive(false);
        sceneMainChar.transform.position = agentStartPoint;
        sceneMainChar.SetActive(true);
    }

    public void DropCola()
    {
        holdCola = false;
    }

    public void TurnOnVomit()
    {
        vomitSystem.SetActive(true);
    }
    public void TurnOFFVomit()
    {
        vomitSystem.SetActive(false);
    }


    public void completeColaLevel()
    {
        LevelCompletePanel.Instance.completeLevel();
    }

}
