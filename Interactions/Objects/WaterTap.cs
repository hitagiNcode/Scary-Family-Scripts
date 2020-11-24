using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : InteractableObj
{
    public GameObject waterParticle;
    private bool waterBool;
    public PianoScene script;
    public AudioClip waterClipOpen;
    public AudioClip waterClipClose;

    private AudioSource m_source;
    // Start is called before the first frame update
    void Start()
    {
        m_source = GetComponent<AudioSource>();
        waterParticle.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();
        doWork();
    }
    void doWork()
    {

        if (script.bucketOnSpot)
        {
            script.FillBucket();
        }
        else
        {
            particleVisibility();
        }

        
    }

    public void particleVisibility()
    {
        waterBool = !waterBool;
        if (waterBool)
        {
            waterParticle.SetActive(true);
            m_source.PlayOneShot(waterClipOpen, 0.4f);
        }
        if (!waterBool)
        {
            waterParticle.SetActive(false);
            m_source.PlayOneShot(waterClipClose, 0.4f);
        }
    }


}
