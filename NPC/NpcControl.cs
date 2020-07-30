using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class NpcControl : MonoBehaviour
{

    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public ThirdPersonCharacter1  character { get; private set; }

    public float baseSpeed;

    //---- bu alan Destination managerdan gelecek
    public Vector3 myDest;
    // Oyuncu bir obje koyup attıgı zaman npc gidip onu alabilsin diye
    public GameObject myDestInteractable;
    //----------------------------------

   
    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter1>();

        baseSpeed = agent.speed;
        agent.updateRotation = false;
        agent.updatePosition = true;
        
    }

    
    void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);

        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);

        //This Decreases the speed of agent offmesh link
        if (agent.isOnOffMeshLink)
        {
            agent.speed = baseSpeed / 3;
        }
        else
        {
            agent.speed = baseSpeed;
        }
        //----------------------------------------------

    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }



}
