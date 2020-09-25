using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForNewspaper : InteractableObj
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
            TipsManager.Instance.SendTipToPlayer("The newspaper is set!");
            MainAudioManager.Instance.PlayRightItem();
            transform.gameObject.tag = "Untagged";
            sceneScript.PlacedNewspaper();
            RayCaster.instance.SetPlayerhandEmpty();
        }
        else
        {
            TipsManager.Instance.SendTipToPlayer("Find a newspaper to place!");
            MainAudioManager.Instance.PlayWrongItem();
        }

    }
}
