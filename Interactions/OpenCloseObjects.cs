using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseObjects : InteractableObj
{
    private Animator _anim;
    private bool isOpen;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();

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

}
