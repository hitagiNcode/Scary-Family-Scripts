using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

public class ValuesManager : MonoBehaviour
{
    public static ValuesManager Instance {get; private set;}

    public Text goldText;
    public Text diamondText;
    public Text livesText;
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
        GetValue("Gold", goldText);
        GetValue("Diamond", diamondText);
        GetValue("Lives", livesText);
        
    }



    private void GetValue(string stringValue, Text inputText)
    {
        if (PlayerPrefs.HasKey(stringValue))
        {
            inputText.text = PlayerPrefs.GetInt(stringValue).ToString();
        }
        else
        {
            inputText.text = "0";
        }
    }

    public void AddValue(string stringValue, int addAmount) 
    {
        int currentValue = PlayerPrefs.GetInt(stringValue, 0);

        PlayerPrefs.SetInt(stringValue, currentValue + addAmount);

    }

    public void RemoveValue(string stringValue, int removeAmount)
    {
        int currentValue = PlayerPrefs.GetInt(stringValue, 0);

        PlayerPrefs.SetInt(stringValue, currentValue - removeAmount);

    }

    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll();
        GetValue("Gold", goldText);
        GetValue("Diamond", diamondText);
        GetValue("Lives", livesText);
    }

}
