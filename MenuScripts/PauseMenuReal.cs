using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuReal : MonoBehaviour
{
   public static PauseMenuReal  Instance { get; private set; }

    public GameObject pauseMenuUI;
    public GameObject pauseMenuPanel;
    public GameObject optionsMenuUI;

    public GameObject PlayerUI;
    public Image[] imagesUI;

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
        pauseMenuPanel.SetActive(false);
    }


    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        
        optionsMenuUI.SetActive(false);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        

    }

    public void OptionsMenu()
    {
        optionsMenuUI.SetActive(true);
    }


    public void SetPlayerUIDeactive()
    {
        PlayerUI.SetActive(false);
        for (int i = 0; i < imagesUI.Length; i++)
        {
            imagesUI[i].enabled = false;
        }
    }

    public void SetPlayerUIActive()
    {
        PlayerUI.SetActive(true);
        for (int i = 0; i < imagesUI.Length; i++)
        {
            imagesUI[i].enabled = true;
        }
    }

    public void ButtonLoadMainMenu()
    {
        LevelLoader.Instance.LoadMainMenu();
    }
}
