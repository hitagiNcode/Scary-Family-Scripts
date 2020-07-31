using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDestManager : MonoBehaviour
{
    public static NpcDestManager instance;
    public GameObject[] randomDests;
    
  
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        randomDests = GameObject.FindGameObjectsWithTag("RandomDest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getRandomDest()
    {
        return randomDests[Random.Range(0, randomDests.Length)];
    }
    
}
