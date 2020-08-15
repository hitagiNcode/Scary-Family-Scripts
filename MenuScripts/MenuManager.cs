using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject characterBoi;
    public GameObject CharacterPanel;
    public Text VersionText;
    // Start is called before the first frame update
    void Start()
    {
        CharacterPanelOFF();
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
    }
    public void CharacterPanelOFF()
    {
        CharacterPanel.SetActive(false);
        characterBoi.SetActive(false);
    }

}
