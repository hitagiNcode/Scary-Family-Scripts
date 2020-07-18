using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    public int itemId;
    // If the item is liftable check true (false for doors closets etc..)
    public bool isLiftAble = false;

    [HideInInspector]
    public GameObject itemSelf;

    [HideInInspector]
    public Rigidbody itemRigid;

    //Show the hand guide of the player
    public GameObject itemGuide;
    //Hand position of the object
    public Vector3 handPosition;
    //Hand rotation of the object
    public Vector3 handRotation;

    public virtual void Interact()
    {
        if (isLiftAble)
        {
            PickUp();
        }

    }

    public virtual void Throw()
    {
        if (isLiftAble)
        {
            ThrowObj();
        }

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
        itemRigid.AddForce(itemGuide.transform.forward * 100);


    }



    public void GetObjScripts()
    {
        if (isLiftAble == true)
        {

            itemSelf = this.gameObject;
            itemRigid = itemSelf.GetComponent<Rigidbody>();

        }
    }

}
