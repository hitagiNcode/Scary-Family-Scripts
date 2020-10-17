using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCutSceneManager : MonoBehaviour
{
    public GameObject CutSceneHolder;

    // Start is called before the first frame update
    void Start()
    {
        switch (LevelLoader.Instance.selectedCutScene)
        {
            case LevelLoader.CutScene.DrinkCola:
                  CutSceneHolder.GetComponent<DrinkColaScene>().enabled = true;
                PlayerPrefs.SetInt("SelectedScene", 1);
                Debug.Log("scene drinkcola is loaded");
                break;
            case LevelLoader.CutScene.NewspaperRush:
                CutSceneHolder.GetComponent<NewsPaperScene>().enabled = true;
                PlayerPrefs.SetInt("SelectedScene", 2);
                Debug.Log("scene newspapaer is loaded");
                break;
            case LevelLoader.CutScene.BBQFire:
                CutSceneHolder.GetComponent<BBQScene>().enabled = true;
                PlayerPrefs.SetInt("SelectedScene", 3);
                Debug.Log("scene bbqfire is loaded");
                break;
            default:
                Debug.Log("Scene Secilmedi");
                PlayerPrefs.SetInt("SelectedScene", 0);
                break;
        }


    }


   
}
