using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOpenClose : InteractableObj
{

    private Animator _anim;
    private bool isOpen;
    private AudioSource m_source;

    public AudioClip firstClip;
    public AudioClip secondClip;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        m_source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        isOpen = !isOpen;
        if (isOpen)
        {
            _anim.SetBool("Open", true);
            m_source.PlayOneShot(firstClip, 0.3f);
        }
        else
        {
            _anim.SetBool("Open", false);
            m_source.PlayOneShot(secondClip, 0.3f);
        }
    }

}
