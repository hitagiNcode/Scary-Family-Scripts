using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDestManager : MonoBehaviour
{
    public static NpcDestManager instance;
    public GameObject[] randomDests;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        randomDests = GameObject.FindGameObjectsWithTag("RandomDest");
    }

    

    public GameObject getRandomDest()
    {
        return randomDests[Random.Range(0, randomDests.Length)];
    }
    
}
