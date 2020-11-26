using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public GameObject coinPanel;
    private GridLayoutGroup _coingrid;

    public GameObject itemPrefab;

    public ShopItem[] coinItems;
    public ShopItem[] diamondItems;

    // Start is called before the first frame update
    void Start()
    {
        coinPanel.SetActive(true);
        _coingrid = coinPanel.GetComponent<GridLayoutGroup>();
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
       
    }
}
