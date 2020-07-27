using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class NpcControl : MonoBehaviour
{
    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }

    public ThirdPersonCharacter1  character { get; private set; }

    //---- bu alan Destination managerdan gelecek
    public Vector3 myDest;
    // Oyuncu bir obje koyup attıgı zaman npc gidip onu alabilsin diye
    public GameObject myDestInteractable;
    //----------------------------------

   
    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter1>();

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

    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}
