using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI versionText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopIntro());
        versionText.text = "v" + Application.version;
    }

    
    IEnumerator StopIntro()
    {
        Debug.Log("intro izle az bee");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
