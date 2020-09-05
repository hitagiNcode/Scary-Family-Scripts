using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : MonoBehaviour
{
    private AudioSource m_audsource;
    public AudioClip failAudioClip;

    public GameObject pauseMenuUI;
    public GameObject levelFailPanel;
    public Cinemachine.CinemachineVirtualCamera npcCamera;
    public static LevelFailPanel Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_audsource = GameObject.FindGameObjectWithTag("MainAudioSource").GetComponent<AudioSource>();
        pauseMenuUI.SetActive(false);
        levelFailPanel.SetActive(false);
    }

    public void FailLevel()
    {
        StartCoroutine(DelayedFail());
    }

    IEnumerator DelayedFail()
    {
        npcCamera.Priority = 21;
        PauseMenuReal.Instance.SetPlayerUIDeactive();
        yield return new WaitForSeconds(3f);
        pauseMenuUI.SetActive(true);
        levelFailPanel.SetActive(true);
        m_audsource.PlayOneShot(failAudioClip);
        StartCoroutine(DelayedCameraBack());
    }

    IEnumerator DelayedCameraBack()
    {
        yield return new WaitForSeconds(4f);
        npcCamera.Priority = 9;
        StartCoroutine(DelayedGameStop());
    }

    IEnumerator DelayedGameStop()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }
   
}
