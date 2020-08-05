using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftableObjects : InteractableObj
{
    
    [HideInInspector]
    public GameObject itemSelf;

    [HideInInspector]
    public Rigidbody itemRigid;

    public Image itemImg;

    //Show the hand guide of the player
    public GameObject itemGuide;
    //Hand position of the object
    public Vector3 handPosition;
    //Hand rotation of the object
    public Vector3 handRotation;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public override void Throw()
    {
        base.Throw();
        ThrowObj();
    }

    private void PickUp()
    {
        itemRigid.useGravity = false;
        itemRigid.isKinematic = true;
        itemSelf.transform.parent = itemGuide.transform;
        itemSelf.transform.localPosition = handPosition;
        itemSelf.transform.localEulerAngles = handRotation;
    }

    void ThrowObj()
    {
        itemSelf.transform.parent = null;
        itemRigid.isKinematic = false;
        itemRigid.useGravity = true;
        itemRigid.AddForce(itemGuide.transform.forward * 200);
    }

    public void GetObjScripts()
    {
            itemSelf = this.gameObject;
            itemRigid = itemSelf.GetComponent<Rigidbody>();
    }

}
