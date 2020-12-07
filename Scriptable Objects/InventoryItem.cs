using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public int itemId;

    public Sprite artWork;

    public string itemName;
   
}
