using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : InteractableObj
{
    public PianoScene script;
    public int possibleItemId;
    public AudioClip pianoClip;
    private AudioSource m_source;
    // Start is called before the first frame update
    void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        if (PlayerPrefs.GetInt("SelectedScene",0) == 4)
        {
            CheckItem();
        }
        else
        {
            m_source.PlayOneShot(pianoClip, 0.4f);
        }
    }

    void CheckItem()
    {
        if (RayCaster.instance.isHoldingRightItem(possibleItemId))
        {
            
            if (script.bucketOnSpot)
            {
                MainAudioManager.Instance.PlayRightItem();
                RayCaster.instance.SetPlayerhandEmpty();
                script.bucket.SetActive(false);
                TipsManager.Instance.SendTipToPlayer("Great job, now let's watch!");
                script.FillPiano();
                transform.gameObject.tag = "Untagged";
            }
            else
            {
                TipsManager.Instance.SendTipToPlayer("Fill bucket with water!");
                MainAudioManager.Instance.PlayWrongItem();
            }
            
        }
        else
        {
            TipsManager.Instance.SendTipToPlayer("You need a bucket with water.");
            MainAudioManager.Instance.PlayWrongItem();
        }

    }


}
