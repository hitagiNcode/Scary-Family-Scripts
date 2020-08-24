using UnityEngine;

public class SingleDoor : InteractableObj
{
    private Animator _anim;
    private AudioSource m_AudSource;
    public AudioClip openClip;
    public AudioClip closeClip;

    void Start()
    {
        _anim = GetComponent<Animator>();
        m_AudSource = GetComponent<AudioSource>();

        m_AudSource.spatialBlend = 1f;
    }

    public override void Interact()
    {
        base.Interact();

        if (_anim.GetBool("Open"))
        {
            _anim.SetBool("Open", false);
            m_AudSource.PlayOneShot(closeClip, 0.5f);
        }
        else
        {
            _anim.SetBool("Open", true);
            m_AudSource.PlayOneShot(openClip, 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", true);
            m_AudSource.PlayOneShot(openClip, 0.5f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Npc"))
        {
            _anim.SetBool("Open", false);
            m_AudSource.PlayOneShot(closeClip, 0.5f);
        }
    }


}


