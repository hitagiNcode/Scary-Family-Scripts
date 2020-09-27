using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MergeScript : MonoBehaviour
{
    public FloatingJoystick moveJoystick;
    private FirstPersonController m_controller;
    
    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_controller.runAxis = moveJoystick.Direction;
    }
}
