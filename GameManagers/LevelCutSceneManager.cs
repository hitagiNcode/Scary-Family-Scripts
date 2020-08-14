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
        switch (LevelLoader.Instance.SelectedSceneValue)
        {
            case 1:
                  CutSceneHolder.GetComponent<DrinkColaScene>().enabled = true;
                break;
            default:
                Debug.Log("Scene Secilmedi");
                break;
        }


    }

   
}
