using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject levelUpPanel;
    public AudioClip levelDanceSound;

    public static LevelCompletePanel Instance { get; private set; }

    public Text goldText;

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
        MainAudioManager.Instance.PlayOne(levelDanceSound);
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

    public void GoldEarnedAmount(int amount)
    {
        int currentValue = PlayerPrefs.GetInt("Gold", 0);
        PlayerPrefs.SetInt("Gold", currentValue + amount);
        goldText.text = "" + amount;
    }

}
