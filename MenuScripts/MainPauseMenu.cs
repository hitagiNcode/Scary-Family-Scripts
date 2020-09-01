using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPauseMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        OptionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
    }
    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);
    }

    
}
