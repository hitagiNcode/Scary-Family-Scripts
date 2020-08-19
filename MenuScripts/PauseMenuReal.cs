using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuReal : MonoBehaviour
{
    // Use this to send audio manager command to play pause menu music
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseMenuPanel;
    public GameObject optionsMenuUI;

    public GameObject PlayerUI;
    public Image[] imagesUI;



    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        optionsMenuUI.SetActive(false);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

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


}
