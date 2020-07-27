using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", false);
        }
    }
}
