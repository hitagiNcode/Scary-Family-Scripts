using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : InteractableObj
{
    //You need to declare an itemid it can be a key
    public int requireItem;
    private Animator _anim;
    private bool isOpen;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        //This if checks the required item from raycaster handObj
        if (RayCaster.instance.isHoldingRightItem(requireItem))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                _anim.SetBool("Open", true);
            }
            else
            {
                _anim.SetBool("Open", false);
            }

        }
        else
        {
            Debug.Log("you need a key");
        }
        
    }
}
