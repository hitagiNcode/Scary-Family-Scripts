using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopConfirmation : MonoBehaviour
{
    public ShopItem _data;

    public Image itemImg;

    public Text priceText;

    public Button _button;

    public void SetDisplay()
    {
        itemImg.sprite = _data.artWork;

        priceText.text = _data.price.ToString();

        if (PlayerPrefs.GetInt("Gold", 0) < _data.price) 
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
        
    }


}
