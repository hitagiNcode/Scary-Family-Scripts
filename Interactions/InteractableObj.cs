using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    public ShopItem _data;
    public int itemId;
    public bool isLiftable;
    private GameObject gameObjSelf;

    public virtual void Interact()
    {
        

    }

    public virtual void Throw()
    {
       

    }

   public GameObject GetGameObj()
    {
        return this.gameObject;
    }

}
