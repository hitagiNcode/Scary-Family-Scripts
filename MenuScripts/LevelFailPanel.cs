using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : MonoBehaviour
{
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
        yield return new WaitForSeconds(4f);
        pauseMenuUI.SetActive(true);
        levelFailPanel.SetActive(true);
    }
   
}
