using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkColaScene : MonoBehaviour
{
    public GameObject cola;
    public GameObject sceneDrinkCola;
    public GameObject SceneCharacter;

    // Start is called before the first frame update
    void Start()
    {
        cola.SetActive(true);
        sceneDrinkCola.SetActive(true);
        SceneCharacter.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
