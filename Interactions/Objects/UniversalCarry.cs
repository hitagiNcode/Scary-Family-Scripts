using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalCarry : InteractableObj
{
    // Start is called before the first frame update
    void Start()
    {
        //This calls a function which is needed for to get item scripts (if only obj is liftable)
        GetObjScripts();
        
    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void Throw()
    {
        base.Throw();
    }


}
