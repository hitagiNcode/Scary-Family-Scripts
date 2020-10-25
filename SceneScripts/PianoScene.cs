using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoScene : MonoBehaviour
{
    public Vector3 agentStartPoint;
    public GameObject sceneMainChar;
    public GameObject sceneCharacter;
    public GameObject firstCutScene;
    public GameObject secondCutScene;
    public Transform agentMovePos;
    private NpcControl mainCharController;

    //Special to scene
    public GameObject waterOfPiano;
    public GameObject bucket;
    public GameObject waterOfBucket;
    public GameObject particlesOfWater;
    public bool bucketOnSpot = false;
    
    


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
        
        firstCutScene.SetActive(true);
        secondCutScene.SetActive(false);
        sceneMainChar.SetActive(false);
        sceneCharacter.SetActive(true);
        mainCharController = sceneMainChar.GetComponent<NpcControl>();
        mainCharController.isCoroutineStarted = false;
    }

    public void DeActivateAfterScene()
    {
        sceneCharacter.SetActive(false);
        sceneMainChar.transform.position = agentStartPoint;
        sceneMainChar.SetActive(true);
        TipsManager.Instance.SendTipToPlayer("Fill piano with water!");
    }

    public void completeLevel()
    {
        LevelCompletePanel.Instance.completeLevel();
        LevelCompletePanel.Instance.GoldEarnedAmount(100);
    }

    public void FillBucket()
    {
        StartCoroutine(fillBucket());
    }
    
    IEnumerator fillBucket()
    {
        //particlesOfWater.SetActive(true);
        yield return new WaitForSeconds(2f);
        //particlesOfWater.SetActive(false);
        waterOfBucket.SetActive(true);
        transform.gameObject.tag = "Interactable";
        bucket.GetComponent<BoxCollider>().enabled = true;
    }

    public void FillPiano()
    {
        waterOfPiano.SetActive(true);
    }
}
