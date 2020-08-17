using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaSeneCola : InteractableObj
{
    public DrinkColaScene colaSceneScript;
    public int[] posibbleItems;


    public override void Interact()
    {
        base.Interact();
        CheckItem();
    }

    void CheckItem()
    {
        for (int i = 0; i < posibbleItems.Length; i++)
        {
            if (RayCaster.instance.isHoldingRightItem(posibbleItems[i]))
            {
                colaSceneScript.drinkIsReady = true;
                break;
            }
            else
            {
                Debug.Log("you need an item to mix cola");
            }

        }
    }

}
