﻿using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public enum CutScene { NoScene, DrinkCola, NewspaperRush, BBQFire, PianoScene};
    public CutScene selectedCutScene = CutScene.DrinkCola;

    public static LevelLoader Instance { get; private set; }


    //--------------- Find at start----------
    public GameObject loadingScreenHolder;
    public GameObject loadingPanel;
    public Slider slider;
    public Text progressText;
    //---------------------------------------

    private int currentSceneNumber = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }


    private void Update()
    {
        if (loadingScreenHolder == null)
        {
            FindLoadingScreenHolder();
        }
    }

    private void FindLoadingScreenHolder()
    {
        loadingScreenHolder = GameObject.FindGameObjectWithTag("LoadingPanel");
        loadingPanel = loadingScreenHolder.transform.Find("LoadingPanel").gameObject;
        slider = loadingPanel.GetComponentInChildren<Slider>();
        progressText = loadingPanel.GetComponentInChildren<Text>();

        loadingPanel.SetActive(false);
    }

    public void StartGameLevel()
    {
        StartCoroutine(LoadAsynchoronously(2));
        Time.timeScale = 1f;
    }

    IEnumerator LoadAsynchoronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanel.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }



    public void SelectSceneAndStartGame(int scenenumber)
    {
        currentSceneNumber = scenenumber;
        PlayerPrefs.SetInt("SelectedScene", scenenumber);
        switch (scenenumber)
        {
            case 0:
                selectedCutScene = CutScene.NoScene;
                
                StartGameLevel();
                
                break;
            case 1:
                selectedCutScene = CutScene.DrinkCola;
                
                StartGameLevel();
                break;
            case 2:
                selectedCutScene = CutScene.NewspaperRush;
                
                StartGameLevel();
                break;
            case 3:
                selectedCutScene = CutScene.BBQFire;
                
                StartGameLevel();
                break;
            case 4:
                selectedCutScene = CutScene.PianoScene;
                StartGameLevel();
                break;
            default:
                selectedCutScene = CutScene.NoScene;
                currentSceneNumber = 0;
                StartGameLevel();
                break;
        }
        
    }

    public void LoadAndStartNextLevel()
    {
        SelectSceneAndStartGame(PlayerPrefs.GetInt("SelectedScene") + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ReplaySameLevel()
    {
        SelectSceneAndStartGame(PlayerPrefs.GetInt("SelectedScene"));
    }
}
