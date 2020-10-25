using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : InteractableObj
{
    public GameObject waterParticle;
    private bool waterBool;
    public PianoScene script;
    // Start is called before the first frame update

    public override void Interact()
    {
        base.Interact();
        doWork();
    }
    void doWork()
    {

        if (script.bucketOnSpot)
        {
            script.FillBucket();
        }

        //particleVisibility();
    }

    void particleVisibility()
    {
        waterBool = !waterBool;
        if (!waterBool)
        {
            waterParticle.SetActive(true);
        }
        if (waterBool)
        {
            waterParticle.SetActive(false);
        }
    }

}
