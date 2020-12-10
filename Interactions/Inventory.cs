using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Holding more items than 1 is gonna continue after i developed game more
   
    public static Inventory instance;

    public GridLayoutGroup _inventoryGrid;

    public GameObject itemPrefab;

    //public ShopItem[] currentInventory = new ShopItem[3];

    List<InventoryItem> _currentInv = new List<InventoryItem>();


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }


    public void AddItem(ShopItem _item)
    {
        if (_currentInv.Count > 3)
        {
            TipsManager.Instance.SendTipToPlayer("I can't carry more than 3 items");
            //soundmanager put inventory full sound
        }
        else
        {
            GameObject newObj = GameObject.Instantiate(itemPrefab, _inventoryGrid.transform);
            StartCoroutine(WaitForHold(newObj));
            _currentInv.Add(new InventoryItem(newObj, _item));  
            InventoryItemDisplay objDisplay = newObj.GetComponent<InventoryItemDisplay>();
            objDisplay._master = this;
            objDisplay._data = _item;
            objDisplay.SetDisplay();
                
        }

    }

    public void RemoveItem(ShopItem _item)
    {
        for (int i = 0; i < _currentInv.Count; i++)
        {
            if (_currentInv[i]._data.itemId == _item.itemId)
            {
                StartCoroutine(WaitForDestroy(_currentInv[i]._slotObj));
                _currentInv.Remove(_currentInv[i]);
                break;
            }
        }
    }

    public void ChangeHoldingItem()
    {
        
    }


    IEnumerator WaitForDestroy(GameObject _obj)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(_obj);
    }

    IEnumerator WaitForHold(GameObject _obj)
    {
        _obj.SetActive(false);
        yield return new WaitForSeconds(1f);
        _obj.SetActive(true);
    }
}

public class InventoryItem
{
    public GameObject _slotObj;
    public ShopItem _data;

    public InventoryItem(GameObject _obj, ShopItem _dat)
    {
        _slotObj = _obj;
        _data = _dat;
    }

}