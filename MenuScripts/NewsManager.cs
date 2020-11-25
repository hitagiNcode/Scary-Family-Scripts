using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public GameObject newsPanel;
    private bool panelBool = true;
    // Start is called before the first frame update
    void Start()
    {
        newsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelToggleFunc()
    {
        if (panelBool)
        {
            newsPanel.SetActive(true);
            panelBool = false;
        }
        else
        {
            newsPanel.SetActive(false);
            panelBool = true;
        }

    }
}
