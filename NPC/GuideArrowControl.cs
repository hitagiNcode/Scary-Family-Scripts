using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideArrowControl : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;


    // I need to make agent turn to the way not go to there

    // And need to reverse the head of arrow
    
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //agent.updatePosition = false;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            
        }
    }


    public void GuideToObj(Transform _target)
    {
        target = _target;
    }
}
