using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public static Inventory instance;
    //Put your GridLayout Group here so it can add InventorySlot Prefab
    public GridLayoutGroup _inventoryGrid;
    //Prefab of InventorySlot
    public GameObject itemPrefab;
    //A list of current inventory items 
    public List<InventoryItem> _currentInv = new List<InventoryItem>();


    private void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        CheckBoughtItems();
    }

    //Mostly called from Raycaster after interact button clicked
    public void AddItem(ShopItem _item, InteractableObj _script)
    {
       
            GameObject newObj = GameObject.Instantiate(itemPrefab, _inventoryGrid.transform);
            StartCoroutine(WaitForHold(newObj));
            _currentInv.Add(new InventoryItem(newObj, _item, _script.GetGameObj()));  
            InventoryItemDisplay objDisplay = newObj.GetComponent<InventoryItemDisplay>();
            objDisplay._master = this;
            objDisplay._data = _item;
            objDisplay.SetDisplay(_script);
            
    }

    //Also gets called from Raycaster when throw button is clicked
    public void RemoveItem(GameObject _obj)
    {
        for (int i = 0; i < _currentInv.Count; i++)
        {
            if (GameObject.ReferenceEquals(_currentInv[i]._realObj, _obj))
            {
                
                StartCoroutine(WaitForDestroy(_currentInv[i]._slotObj));
                _currentInv.Remove(_currentInv[i]);
                
                break;
            }
        }
    }
    //I need to wait for animations before I destroy the Inventory slot prefab- I will use object pooling soon
    IEnumerator WaitForDestroy(GameObject _obj)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(_obj);
    }
    //Waiting for animation before setting game object active
    IEnumerator WaitForHold(GameObject _obj)
    {
        _obj.SetActive(false);
        yield return new WaitForSeconds(1f);
        _obj.SetActive(true);
    }
    //Clears after 3 seconds if player clicked wrong quest can have time not to loose items.
    IEnumerator ClearTheShopList()
    {
        yield return new WaitForSeconds(4f);
        ItemManager.Instance._boughtItems.Clear();
    }

    //Checks bought items from shop only at the start of the game and adds it to inventory
    //After check all bought items clears the list
    public void CheckBoughtItems()
    {
        List<BoughtItem> boughtItems = ItemManager.Instance._boughtItems;
        for (int i = 0; i < boughtItems.Count; i++)
        {
            
            AddFromShop(boughtItems[i]._item);

          
        }

        StartCoroutine(ClearTheShopList());
        
    }

    //Special function for creating game items from prefabs that bought from shop
    private void AddFromShop(ShopItem _item)
    {
        GameObject newObj = GameObject.Instantiate(itemPrefab, _inventoryGrid.transform);
        GameObject _newItem = GameObject.Instantiate(_item.itemPrefab, RayCaster.instance.itemGuide.transform);
        LiftableObjects _script = _newItem.GetComponent<LiftableObjects>();
        _script.GetObjScripts();
        _script.itemRigid.useGravity = false;
        _script.itemRigid.isKinematic = true;
        _newItem.transform.localPosition = _script.handPosition;
        _newItem.transform.localEulerAngles = _script.handRotation;
        _newItem.transform.localScale = _item.handScale;
        _currentInv.Add(new InventoryItem(newObj, _item, _newItem));
        InventoryItemDisplay objDisplay = newObj.GetComponent<InventoryItemDisplay>();
        objDisplay._master = this;
        objDisplay._data = _item;
        objDisplay.SetDisplay(_script);
        _newItem.SetActive(false);
    }

    
   
}

public class InventoryItem
{
    public GameObject _slotObj;
    public ShopItem _data;
    public GameObject _realObj;

    public InventoryItem(GameObject _obj, ShopItem _dat,GameObject _rObj)
    {
        _slotObj = _obj;
        _data = _dat;
        _realObj = _rObj;
    }

}