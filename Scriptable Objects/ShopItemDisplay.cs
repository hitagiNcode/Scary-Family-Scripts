using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    public ShopItem _data;

    public Image itemImg;

    public Text priceText;

    public AudioClip _buttonClip;

    public AudioSource _inheritedSource;

    private MultiImageButton _button;
    public void SetDisplay()
    {
        itemImg.sprite = _data.artWork;

        priceText.text = _data.price.ToString();
        SetButtonValues();
    }

    public void SetButtonValues()
    {
        _button = GetComponent<MultiImageButton>();
        _button.onClick.AddListener(ButtonSound);
        _button.onClick.AddListener(BuyItem);
    }

    private void ButtonSound()
    {
        _inheritedSource.PlayOneShot(_buttonClip, 0.4f);
    }

    private void BuyItem()
    {

    }
   
}
