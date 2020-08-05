using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Holding more items than 1 is gonna continue after i developed game more
    
    public GameObject[] inventoryObjects ;

    public Image[] slots;
    public bool[] isFull ;
    public static Inventory instance;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void AddItem(GameObject obj, Image slotsImg)
    {
        for (int i = 0; i < inventoryObjects.Length; i++)
        {
            if (isFull[i] == false)
            {
                isFull[i] = true;
                slots[i] = slotsImg;
                inventoryObjects[i] = obj;
                break;
            }

        }
    }

    public void SelectItem()
    {

    }


}
