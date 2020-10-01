using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : InteractableObj
{
    public NewsPaperScene sceneScript;
    public NpcControl gelenNpc;

    private AudioSource m_source;
    public AudioClip ringClip;

    private void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        
        m_source.PlayOneShot(ringClip, 0.3f);

        sceneScript.RingBell();
        gelenNpc.GoDoorBell(transform);
    }

    
}
