using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundVolumeScript : MonoBehaviour
{
    private AudioSource m_audsource;
    private bool isUpstarted = false;
    private bool isDownStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        m_audsource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isUpstarted)
        {
            StartCoroutine(ChangeVolumeUp());
        }
        if (!isDownStarted)
        {
            StartCoroutine(ChangeVolumeDown());
        }
        
    }


    IEnumerator ChangeVolumeUp()
    {
        isUpstarted = true;
        
        yield return new WaitForSeconds(40f);
        
        m_audsource.volume = 0.25f;
        isUpstarted = false;
    }
    IEnumerator ChangeVolumeDown()
    {
        isDownStarted = true;
        
        yield return new WaitForSeconds(30f);
        
        m_audsource.volume = 0.1f;
        isDownStarted = false;
    }

}
