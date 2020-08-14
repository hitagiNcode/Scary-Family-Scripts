using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text VersionText;
    // Start is called before the first frame update
    void Start()
    {
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
}
