using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
        bool isValid = false;
        for (int i = 0; i < posibbleItems.Length; i++)
        {
            if (RayCaster.instance.isHoldingRightItem(posibbleItems[i]))
            {
               
                colaSceneScript.drinkIsReady = true;
                isValid = true;
                TipsManager.Instance.SendTipToPlayer("Drink is ready now run away!");
                transform.gameObject.tag = "Untagged";
                break;
            }
        }
        if (!isValid)
        {
            TipsManager.Instance.SendTipToPlayer("Find something right to mix!");
        }
    }

}
