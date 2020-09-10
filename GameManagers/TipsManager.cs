using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    public static TipsManager Instance { get; private set; }

    public GameObject tipPanel;
    public Text tipText;

    private Animator m_animator;
    private bool tipOnscreen = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
    }

    private void Start()
    {
        m_animator = tipPanel.GetComponent<Animator>();
        m_animator.SetBool("Visible", false);
    }

    public void SendTipToPlayer(string textString)
    {
        if (!tipOnscreen)
        {
            tipText.text = textString;
            StartCoroutine(FadeInOut());
        }
        
    }

    private IEnumerator FadeInOut()
    {
        tipOnscreen = true;
        m_animator.SetBool("Visible", true);
        yield return new WaitForSeconds(5f);
        m_animator.SetBool("Visible", false);
        tipOnscreen = false;
    }
}
