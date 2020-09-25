using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForTrap : InteractableObj
{
    public NewsPaperScene sceneScript;
    public int possibleItemId;

    public override void Interact()
    {
        base.Interact();
        CheckItem();
    }

    void CheckItem()
    {
        if (RayCaster.instance.isHoldingRightItem(possibleItemId))
        {
            TipsManager.Instance.SendTipToPlayer("The trap is set!");
            MainAudioManager.Instance.PlayRightItem();
            transform.gameObject.tag = "Untagged";
            sceneScript.PlacedTrap();
            RayCaster.instance.SetPlayerhandEmpty();
        }
        else
        {
            TipsManager.Instance.SendTipToPlayer("Find a trap to place!");
            MainAudioManager.Instance.PlayWrongItem();
        }

    }
}
