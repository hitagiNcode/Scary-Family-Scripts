using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.XR;

public class RayCaster : MonoBehaviour
{
    public static RayCaster instance;

    //Will change it to find Getcomp in child and Animator Might also Compare tag to player body
    public Animator playerAnimator;

    //Player camera
    public Camera m_camera;
    //Raycast Layer
    [SerializeField] private LayerMask layerMaskInteract;
    public Image AimCursor;
    
    public Button interactButton;


    public bool permissionToLift = true;

    //Privates
    //This boolean is for making the AimCursor color back to white only once
    private bool isClickAble;
    private bool isClicked;
    private float rayLength = 2.5f;
    private InteractableObj currentObj;
    private InteractableObj handObj;
    
    //----------------------------

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Vector3 fwd = m_camera.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(m_camera.transform.position, m_camera.transform.forward*rayLength, Color.red);

        if (Physics.Raycast(m_camera.transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Interactable"))
            {   
                ChangeCursor();
            }
            else
            {
                if (isClickAble)
                {
                    ChangeCursorToNormal();
                }
            }
            

            if (isClicked == true)
            {
                
                if (hit.collider.CompareTag("Interactable"))
                {
                    //Calls current obj script and interacts
                    currentObj = hit.collider.gameObject.GetComponent<InteractableObj>();

                    if (currentObj.isLiftable)
                    {
                        if (Inventory.instance._currentInv.Count >= 3)
                        {
                            TipsManager.Instance.SendTipToPlayer("I can't carry more than 3 items");
                            permissionToLift = false;
                            //ThrowGameObject();
                            //handObj = currentObj;
                        }
                        else
                        {
                            if (handObj != null)
                            {
                                
                                StartCoroutine(WaitForItemChange(currentObj));
                                Inventory.instance.AddItem(currentObj._data, currentObj);
                            }
                            else
                            {
                                Inventory.instance.AddItem(currentObj._data, currentObj);
                                handObj = currentObj;
                            }
                            
                        }

                    }

                    currentObj.Interact();
                    isClicked = false;
                }
            }

        }
        else
        {
            if (isClickAble)
            {
                ChangeCursorToNormal();
            }

        }
    }

    private void ChangeCursorToNormal()
    {
        AimCursor.color = new Color32(255, 255, 255, 255);
        interactButton.interactable = false;
        
        isClickAble = false;
    }

    private void ChangeCursor()
    {
        AimCursor.color = new Color32(240, 52, 52, 255);
        interactButton.interactable = true;
        
        isClickAble = true;
    }

    public void InteractButton()
    {
        isClicked = true;
    }

    public void ThrowButton()
    {
        if (handObj != null)
        {
            ThrowGameObject();
        }
        handObj = null;
        
    }

    public bool isHoldingRightItem(int itemid)
    {
        if (handObj != null)
        {
            if (handObj.itemId == itemid)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    public bool IsMyhandEmpty()
    {
        if (handObj == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject GetHandObject() 
    {

        return handObj.GetGameObj();
    }



    public void SetPlayerhandEmpty()
    {
        Inventory.instance.RemoveItem(handObj.GetGameObj());
        handObj = null;
        permissionToLift = true;
        playerAnimator.SetBool("HoldingItem", false);
    }

    private void ThrowGameObject()
    {
        permissionToLift = true;
        Inventory.instance.RemoveItem(handObj.GetGameObj());
        handObj.Throw();
        
    }


    public IEnumerator WaitForItemChange(InteractableObj _obj)
    {
        
        playerAnimator.SetBool("HoldingItem", false);
        yield return new WaitForSeconds(1f);
        playerAnimator.SetBool("HoldingItem", true);
        GetHandObject().SetActive(false);
        _obj.GetGameObj().SetActive(true);
        
        handObj = _obj;
    }

    public IEnumerator BringUpInventoryItem(InteractableObj _obj)
    {

        playerAnimator.SetBool("HoldingItem", false);
        yield return new WaitForSeconds(1f);
        playerAnimator.SetBool("HoldingItem", true);
        _obj.GetGameObj().SetActive(true);
        handObj = _obj;
    }
}
