using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    public ShopItem _data;

    public Image itemImg;

    public Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        itemImg.sprite = _data.artWork;

        priceText.text = _data.price.ToString();
    }

   
}
