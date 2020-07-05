using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuReal : MonoBehaviour
{
    // Use this to send audio manager command to play pause menu music
    public static bool GameIsPaused = false;

    //You need to drag and drop pausemenuUI in inspector to this boi
    public GameObject pauseMenuUI;

    //You need to drag and drop optionsmenuUi in inspector
    public GameObject optionsMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        

        
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        optionsMenuUI.SetActive(false);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void OptionsMenu()
    {
        optionsMenuUI.SetActive(true);
    }

}
