using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance { get; private set; }

    string colaSceneUrl = "https://www.facebook.com/punipunistudio" ;



    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

       

    }


    public void ShowGuideForStar()
    {
        if (DoPlayerHaveStar())
        {
            Application.OpenURL(SceneUrl());
        }
        else
        {
            //Ask If the player want to watch AD to get a star.
            PauseMenuReal.Instance.Pause();
            PauseMenuReal.Instance.AskForWatchAds();
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


    string SceneUrl()
    {
        if (LevelLoader.Instance.selectedCutScene == LevelLoader.CutScene.DrinkCola)
        {
            return colaSceneUrl;
        }
        else
        {
            return "https://instagram.com/punipuni.studio";
        }
        
    }
}
