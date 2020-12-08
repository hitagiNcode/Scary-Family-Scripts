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

    public ShopItem[] currentInventory = new ShopItem[3];


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }


    public void AddItem(ShopItem _item)
    {
        if (currentInventory.Length > 3)
        {
            TipsManager.Instance.SendTipToPlayer("I can't carry more than 3 items");
            //soundmanager put inventory full sound
        }
        else
        {     
            for (int i = 0; i < currentInventory.Length; i++)
            {
                if (currentInventory[i] == null)
                 {
                currentInventory[i] = _item;
                GameObject newObj = GameObject.Instantiate(itemPrefab, _inventoryGrid.transform);
                InventoryItemDisplay objDisplay = newObj.GetComponent<InventoryItemDisplay>();
                objDisplay._master = this;
                objDisplay._data = _item;
                objDisplay.SetDisplay();
                break;
                 }
            }
        }

    }

    public void RemoveItem()
    {

    }

    public void ChangeHoldingItem()
    {

    }


    IEnumerator ChangeItem()
    {

        yield return new WaitForSeconds(3f);


    }
}
