using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class NpcControl : MonoBehaviour
{

    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public ThirdPersonCharacter1  character { get; private set; }

    //Privates
    private float baseSpeed;
    private bool pathReached;
    //----------------------------------

   
    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter1>();

        baseSpeed = agent.speed;
        pathReached = false;
        agent.updateRotation = false;
        agent.updatePosition = true;

        
    }

    
    void Update()
    {
        if (pathReached)
        {
            Debug.Log("run this code");
            target = NpcDestManager.instance.getRandomDest().transform;
            pathReached = false;
        }

        if (target != null)
            agent.SetDestination(target.position);
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);

        HandleOffmeshLinkSpeed();

        IsReached();
    }

    private void IsReached()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                pathReached = true;
            }
        }

    }

    private void HandleOffmeshLinkSpeed()
    {
        if (agent.isOnOffMeshLink)
            agent.speed = baseSpeed / 3;
        else
            agent.speed = baseSpeed;
    }

    IEnumerator WaitAndGetRandomDest()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("new target setted");
        target = NpcDestManager.instance.getRandomDest().transform;
    }

    

}
