using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForBucket : InteractableObj
{
    public PianoScene script;
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
            TipsManager.Instance.SendTipToPlayer("Open the water, now.");
            MainAudioManager.Instance.PlayRightItem();
            transform.gameObject.tag = "Untagged";
            placeBucket();
            script.bucketOnSpot = true;
            RayCaster.instance.SetPlayerhandEmpty();
        }
        else
        {
            TipsManager.Instance.SendTipToPlayer("You need a bucket");
            MainAudioManager.Instance.PlayWrongItem();
        }

    }

    void placeBucket()
    {
        script.bucket.transform.position = transform.position;
        script.bucket.transform.rotation = transform.rotation;
        script.bucket.transform.parent = null;
    }
}
