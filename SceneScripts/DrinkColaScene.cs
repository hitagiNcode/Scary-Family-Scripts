using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkColaScene : MonoBehaviour
{
    public GameObject sceneMainChar;
    public GameObject scenePos;
    public GameObject secondCutScene;
    public GameObject cola;
    public GameObject sceneDrinkCola;
    public GameObject SceneCharacter;
    public Transform oldManHand;

    public bool drinkIsReady = false;

    private bool holdCola = false;
    private Vector3 colaStartPos;
    private NpcControl mainCharController;

    // Start is called before the first frame update
    void Start()
    {
        secondCutScene.SetActive(false);
        ActivateSceneObjs();
        colaStartPos = cola.transform.position;
        mainCharController = sceneMainChar.GetComponent<NpcControl>();
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
    }
}
