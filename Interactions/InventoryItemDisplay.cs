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

    public InteractableObj _script;

    

    public void SetDisplay(InteractableObj _asdObj)
    {
        itemImg.sprite = _data.artWork;
        _button = GetComponent<MultiImageButton>();
        _button.onClick.AddListener(HoldItem);
        _script = _asdObj;
    }

    private void HoldItem()
    {
        if (RayCaster.instance.IsMyhandEmpty())
        {
            RayCaster.instance.ChangeHandItemFromIconEmptyHand(_script);
        }
        else
        {
            RayCaster.instance.ChangeItemFromIcon(_script);
        }
       
    }

}
