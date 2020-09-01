using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject characterBoi;
    public GameObject CharacterPanel;

    public GameObject careerPanel;
    public Text VersionText;

    public GameObject settingsBut;
    public GameObject backBut;
    public GameObject backButv2;
    // Start is called before the first frame update
    void Start()
    {
        CharacterPanelOFF();
        CareerPanelOff();
        VersionText.text = "V" + Application.version;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SocialButton(string SocialUrl)
    {
        Application.OpenURL(SocialUrl);
    }

    public void CharacterPanelOn()
    {
        CharacterPanel.SetActive(true);
        characterBoi.SetActive(true);
        settingsBut.SetActive(false);
        backButv2.SetActive(true);
    }
    public void CharacterPanelOFF()
    {
        CharacterPanel.SetActive(false);
        characterBoi.SetActive(false);
        settingsBut.SetActive(true);
        backButv2.SetActive(false);
    }

    public void CareerPanelOn()
    {
        careerPanel.SetActive(true);
        settingsBut.SetActive(false);
        backBut.SetActive(true);
    }

    public void CareerPanelOff()
    {
        careerPanel.SetActive(false);
        settingsBut.SetActive(true);
        backBut.SetActive(false);
    }

    public void LoadSelectedLevel(int levelValue)
    {
        LevelLoader.Instance.SelectSceneAndStartGame(levelValue);
    }

   
}
