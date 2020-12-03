using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : InteractableObj
{
    public NpcControl gelenNpc;
    private AudioSource m_source;
    public AudioClip ringClip;

    // Start is called before the first frame update
    void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {

        m_source.PlayOneShot(ringClip, 0.3f);
        gelenNpc.GoDoorBell(transform);
    }

}
