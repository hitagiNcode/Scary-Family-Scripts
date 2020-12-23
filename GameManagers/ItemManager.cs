using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public List<BoughtItem> _boughtItems = new List<BoughtItem>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void BuyItem(ShopItem _item)
    {
        _boughtItems.Add(new BoughtItem(_item));
    }

    public bool IsthereEmptySlot()
    {
        if (_boughtItems.Count >= 3)
        {
            
            return false;
            
        }
        else
        {
            
            return true;
        }
    }

}

public class BoughtItem
{
    public ShopItem _item;

    public BoughtItem(ShopItem _data)
    {
        _item = _data;
    }

}
