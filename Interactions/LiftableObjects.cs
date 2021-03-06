﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftableObjects : InteractableObj
{
    
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

    private bool levitating;
    private int upForce = 11;

    private void FixedUpdate()
    {
        if (levitating)
        {
            itemRigid.AddForce(Vector3.up * upForce);
        }
    }

    public override void Interact()
    {
        
        base.Interact();
        if (isLiftable && RayCaster.instance.permissionToLift)
        {
            
                StartCoroutine(PickUpAnim());
        }
        
    }

    public override void Throw()
    {
        base.Throw();
        ThrowObj();
    }

    private void PickUp()
    {
        Debug.Log("pick up");
        RayCaster.instance.playerAnimator.SetBool("HoldingItem", true);
        MainAudioManager.Instance.PlayPickUpAudio();
        itemRigid.useGravity = false;
        itemRigid.isKinematic = true;
        itemSelf.transform.parent = RayCaster.instance.itemGuide.transform;
        itemSelf.transform.localPosition = handPosition;
        itemSelf.transform.localEulerAngles = handRotation;
        RayCaster.instance.handItemPickingUp = false;
    }

    void ThrowObj()
    {
        RayCaster.instance.playerAnimator.SetBool("HoldingItem", false);
        itemSelf.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(WaitAndThrow(0.3f));
    }

    public void GetObjScripts()
    {
            itemSelf = this.gameObject;
            itemRigid = itemSelf.GetComponent<Rigidbody>();
            
    }

    IEnumerator WaitAndThrow (float waitsecs)
    {
        yield return new WaitForSeconds(waitsecs);
        itemSelf.transform.parent = null;
        itemRigid.isKinematic = false;
        itemRigid.useGravity = true;
        itemRigid.AddForce(RayCaster.instance.itemGuide.transform.forward * 200);
    }

    IEnumerator PickUpAnim()
    {
        RayCaster.instance.handItemPickingUp = true;
        itemSelf.GetComponent<BoxCollider>().enabled = false;
        levitating = true;
        
        yield return new WaitForSeconds(1f);
        levitating = false;
        PickUp();
    }
}
