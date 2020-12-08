using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public Inventory _master;

    public ShopItem _data;

    public Image itemImg;

    private MultiImageButton _button;


    public void SetDisplay()
    {
        itemImg.sprite = _data.artWork;
        _button = GetComponent<MultiImageButton>();
        _button.onClick.AddListener(HoldItem);
    }

    private void HoldItem()
    {

    }

}
