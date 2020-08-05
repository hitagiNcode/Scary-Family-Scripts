﻿using UnityEngine;

public class DoubleDoor : InteractableObj
{
    private Animator _anim;
    

    void Start()
    {
        _anim = GetComponentInParent<Animator>();

    }

    public override void Interact()
    {
        base.Interact();

        if (_anim.GetBool("Open"))
        {
            _anim.SetBool("Open", false);
        }
        else
        {
            _anim.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", false);
        }
    }


}

