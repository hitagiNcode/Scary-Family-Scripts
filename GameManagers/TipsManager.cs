using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    public static TipsManager Instance { get; private set; }

    public CanvasGroup tipPanel;
    public Text tipText;

    private bool mFaded = false;

    private float Duration = 0.4f;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
    }
    
    private void Fade()
    {
       
    }


    public void SendTipToPlayer(string textString)
    {
        tipText.text = textString;
    }

}
