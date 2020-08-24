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
        Debug.Log("volume will change in 40 seconds");
        yield return new WaitForSeconds(40f);
        Debug.Log("volume is changed up");
        m_audsource.volume = 0.25f;
        isUpstarted = false;
    }
    IEnumerator ChangeVolumeDown()
    {
        isDownStarted = true;
        Debug.Log("volume will change in 30 secs");
        yield return new WaitForSeconds(30f);
        Debug.Log("volme is down");
        m_audsource.volume = 0.1f;
        isDownStarted = false;
    }

}
