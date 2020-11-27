using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public GameObject coinPanel;
    private GridLayoutGroup _coingrid;

    public GameObject itemPrefab;

    public AudioSource _mainAudio;

    //Put the scriptableobjects in this arrays to show them in panel
    public ShopItem[] coinItems;
    public ShopItem[] diamondItems;

    // Start is called before the first frame update
    void Start()
    {
        coinPanel.SetActive(true);
        _coingrid = coinPanel.GetComponent<GridLayoutGroup>();

        FillCoinPanel();
    }

    
    private void HideAllPanels()
    {
        coinPanel.SetActive(true);
    }

    public void ShowCoinPanel()
    {
        HideAllPanels();
        coinPanel.SetActive(true);
    }

    private void CreateItem(ShopItem _item)
    {
        GameObject newObj = GameObject.Instantiate(itemPrefab, _coingrid.transform);

        ShopItemDisplay objDisplay = newObj.GetComponent<ShopItemDisplay>();
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

}
