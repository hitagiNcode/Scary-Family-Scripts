using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbequee : InteractableObj
{
    public BBQScene scriptBbq;
    public int possibleItem;
   

    public override void Interact()
    {
        base.Interact();
        PourLiquid();
    }

    void PourLiquid()
    {
        if (RayCaster.instance.isHoldingRightItem(possibleItem))
        {

            transform.gameObject.tag = "Untagged";
            StartCoroutine(PourAnimEnum());
        }
        else
        {
            TipsManager.Instance.SendTipToPlayer("Find something to mess with fire!");
            MainAudioManager.Instance.PlayWrongItem();
        }
    }
    IEnumerator PourAnimEnum()
    {
        scriptBbq.fireIsChanged = true;
        TipsManager.Instance.SendTipToPlayer("Look at this fire. Good Job!");
        MainAudioManager.Instance.PlayRightItem();
        GameObject pourObj = RayCaster.instance.GetHandObject();
        pourObj.transform.SetParent(transform);
        pourObj.GetComponent<Animation>().Play();
        RayCaster.instance.SetPlayerhandEmpty();
        

        yield return new WaitForSeconds(2f);
        pourObj.SetActive(false);

    }
}
