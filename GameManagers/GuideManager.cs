using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance { get; private set; }

    public GameObject guideArrowObj;

    public GameObject ColaSceneObject;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //guideArrowObj.SetActive(false);


    }


    public void ShowGuideForStar()
    {
        if (DoPlayerHaveStar())
        {
            guideArrowObj.SetActive(true);
            guideArrowObj.GetComponent<GuideArrowControl>().GuideToObj(SceneObject().transform);
        }
        else
        {
            Debug.Log("Ask If the player want to watch AD to get a star.");
        }
        
    }


    bool DoPlayerHaveStar()
    {
        if (PlayerPrefs.GetInt("Stars", 0) >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    GameObject SceneObject()
    {
        if (LevelLoader.Instance.selectedCutScene == LevelLoader.CutScene.DrinkCola)
        {
            return ColaSceneObject;
        }
        else
        {
            return null;
        }
        
    }
}
