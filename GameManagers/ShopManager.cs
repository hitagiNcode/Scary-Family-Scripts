using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopConfirmation _confirmBox;
    public GameObject confirmPanel;
    public GameObject coinPanel;
    private GridLayoutGroup _coingrid;

    // Currently Selected Item in ShopConfirm
    private ShopItem _currentItem;

    public GameObject itemPrefab;

    public AudioSource _mainAudio;

    //Put the scriptableobjects in this arrays to show them in panel
    public ShopItem[] coinItems;
    public ShopItem[] diamondItems;

    
    void Start()
    {
        confirmPanel.SetActive(false);
        ShowCoinPanel();
        _coingrid = coinPanel.GetComponent<GridLayoutGroup>();

        FillCoinPanel();
        
    }

    
    private void HideAllPanels()
    {
        coinPanel.SetActive(false);
        //confirmPanel.SetActive(false);
    }

    public void ShowCoinPanel()
    {
        HideAllPanels();
        coinPanel.SetActive(true);
    }

    public void ShowConfirmPanel()
    {
        confirmPanel.SetActive(true);
    }

    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    private void CreateItem(ShopItem _item)
    {
        GameObject newObj = GameObject.Instantiate(itemPrefab, _coingrid.transform);

        ShopItemDisplay objDisplay = newObj.GetComponent<ShopItemDisplay>();
        objDisplay._master = this;
        objDisplay._inheritedSource = _mainAudio;
        objDisplay._data = _item;
        objDisplay.SetDisplay();
    }

    private void FillCoinPanel()
    {
        for (int i = 0; i < coinItems.Length; i++)
        {
            CreateItem(coinItems[i]);
        }
    }

    public void OrderConfirmed()
    {
        confirmPanel.SetActive(false);
        //_currentItem  do something
        Debug.Log("You bought: " + _currentItem.name + " for "+_currentItem.price.ToString());
    }

    public void ShopItemClicked(ShopItem itemData)
    {
        CreateShopConfirmBox(itemData);
        _currentItem = itemData;
    }

    private void CreateShopConfirmBox(ShopItem item)
    {
        confirmPanel.SetActive(true);
        _confirmBox._data = item;
        _confirmBox.SetDisplay();
    }

}
