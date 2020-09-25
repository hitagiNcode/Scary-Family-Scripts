using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Trap : LiftableObjects
{
    // Start is called before the first frame update
    void Start()
    {
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
