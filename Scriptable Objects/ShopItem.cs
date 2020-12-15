using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    public int itemId;

    public Sprite artWork = null;

    public string itemName;

    public int price;

    public GameObject itemPrefab;
}
