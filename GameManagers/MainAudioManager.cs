using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioManager : MonoBehaviour
{
    public AudioClip wrongItem;
    public AudioClip rightItem;
    public AudioClip pickUpAudio;


    public static MainAudioManager Instance { get; private set; }
    private AudioSource m_audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    

    public void PlayOne(AudioClip i_audio, float volume = 0.4f)
    {
        m_audioSource.PlayOneShot(i_audio, volume);
    }

    public void PlayWrongItem()
    {
        m_audioSource.PlayOneShot(wrongItem, 0.6f);
    }

    public void PlayRightItem()
    {
        m_audioSource.PlayOneShot(rightItem, 0.6f);
    }

    public void PlayPickUpAudio()
    {
        m_audioSource.PlayOneShot(pickUpAudio, 0.4f);
    }
}
