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
    public GameObject coinShopPanel;
    public GameObject valuesPanel;

    public Text VersionText;
    
    public GameObject settingsBut;
    public GameObject m_backBut;
    public GameObject backButv2;
    // Start is called before the first frame update
    void Start()
    {
        CharacterPanelOFF();
        careerPanel.SetActive(false);
        coinShopPanel.SetActive(false);
        valuesPanel.SetActive(false);
        VersionText.text = "v" + Application.version;

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

    public void LoadSelectedLevel(int levelValue)
    {
        LevelLoader.Instance.SelectSceneAndStartGame(levelValue);
    }

   public void TurnPanelOn(GameObject panel)
    {
        CharacterPanelOFF();
        panel.SetActive(true);
        settingsBut.SetActive(false);
        m_backBut.SetActive(true);
        void CustomClickBack()
        {
            panel.SetActive(false);
            settingsBut.SetActive(true);
            m_backBut.SetActive(false);
            m_backBut.GetComponent<Button>().onClick.RemoveListener(CustomClickBack);
            
        }
        
        m_backBut.GetComponent<Button>().onClick.AddListener(CustomClickBack);
    }

}
