using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ColaSeneCola : InteractableObj
{
    public DrinkColaScene colaSceneScript;
    public int[] posibbleItems;
    //private Animator m_animator;
    
    private void Start()
    {
        //m_animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        CheckItem();
    }

    void CheckItem()
    {
        bool isValid = false;
        for (int i = 0; i < posibbleItems.Length; i++)
        {
            if (RayCaster.instance.isHoldingRightItem(posibbleItems[i]))
            {
               
                colaSceneScript.drinkIsReady = true;
                isValid = true;
                Debug.Log("drinkready");
                break;
            }
        }
        if (!isValid)
        {
            Debug.Log("You need a liquid item to mix with cola");
        }
    }

}
