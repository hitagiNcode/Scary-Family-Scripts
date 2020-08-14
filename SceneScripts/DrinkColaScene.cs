using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkColaScene : MonoBehaviour
{
    public GameObject cola;
    public GameObject sceneDrinkCola;
    public GameObject SceneCharacter;
    public Transform oldManHand;

    private bool holdCola = false;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSceneObjs();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdCola)
        {
            cola.transform.position = oldManHand.transform.position;
            cola.transform.rotation = oldManHand.transform.rotation;
        }
        
    }

    public void HoldColaHand()
    {
        holdCola = true;
    }
    public void ReleaseCola()
    {
        holdCola = false;
    }

    public void ActivateSceneObjs()
    {
        cola.SetActive(true);
        sceneDrinkCola.SetActive(true);
        SceneCharacter.SetActive(true);
    }

    public void DeActivateObjs()
    {
        
        SceneCharacter.SetActive(false);
    }
}
