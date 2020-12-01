using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopIntro());
    }

    
    IEnumerator StopIntro()
    {
        Debug.Log("intro izle az bee");
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);
    }
}
