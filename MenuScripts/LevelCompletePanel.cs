using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePanel : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject levelUpPanel;
    public static LevelCompletePanel Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        levelUpPanel.SetActive(false);
    }

    public void completeLevel()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        levelUpPanel.SetActive(true);
    }


    public void ButtonLoadMainScene()
    {
        LevelLoader.Instance.LoadMainMenu();
    }

    public void ButtonLoadNextLevel()
    {
        LevelLoader.Instance.LoadAndStartNextLevel();
    }

    public void ButtonReplayLevel()
    {
        LevelLoader.Instance.ReplaySameLevel();
    }
}
