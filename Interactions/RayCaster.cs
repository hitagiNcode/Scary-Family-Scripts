using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class RayCaster : MonoBehaviour
{
    //This boolean is for making the AimCursor color back to white only once
    private bool isClickAble;
    private bool isClicked;
    private float rayLength = 2.5f;

    //My int obj script but this will be a virtual function later
    private InteractableObj currentObj;

    private InteractableObj handObj;
    //---------------------------------------------------------
    //Player camera
    public Camera m_camera;
    //Raycast Layer
    [SerializeField] private LayerMask layerMaskInteract;
    public Image AimCursor;
    public Image MobileHand;
    
    //---------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        Vector3 fwd = m_camera.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(m_camera.transform.position, m_camera.transform.forward, Color.red, rayLength);

        if (Physics.Raycast(m_camera.transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider)
            {
                ChangeCursor();
            }

            if (isClicked == true)
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    //Calls current obj script and interacts
                    currentObj = hit.collider.gameObject.GetComponent<InteractableObj>();

                    if (currentObj.isLiftable)
                    {
                        if (handObj != null)
                        {
                            handObj.Throw();
                        }
                        handObj = currentObj;
                    }

                    currentObj.Interact();
                    isClicked = false;
                }
            }

        }

        else
        {   
            //Sets the color only once for better fps just checks bool everytime
            if (isClickAble == true)
            {
                ChangeCursorToNormal();
            }

        }

    }

    private void ChangeCursorToNormal()
    {
        AimCursor.color = new Color32(255, 255, 255, 255);
        MobileHand.color = new Color32(255, 255, 255, 150);
        isClickAble = false;
    }

    private void ChangeCursor()
    {
        AimCursor.color = new Color32(240, 52, 52, 255);
        MobileHand.color = new Color32(255, 255, 255, 255);
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
            handObj.Throw();
        }
        handObj = null;
    }

}
