using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(UnityEngine.AI.NavMesh))]
public class NpcControl : MonoBehaviour
{
    public Transform target;
    public GameObject raycastFrom;

    //Privates
    public bool chasePlayer = false;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public ThirdPersonCharacter1 character { get; private set; }
    private float baseSpeed;
    private bool pathReached;
    private bool isCoroutineStarted = false;
    private float waitSeconds = 5f;
    private GameObject player;
    private bool hitPlayer = false;
    private bool playerIsCaught = false;
    private float traceDistance = 9f;

    //----------------------------------


    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter1>();
        player = GameObject.FindGameObjectWithTag("Player");

        baseSpeed = agent.speed;
        pathReached = false;
        agent.updateRotation = false;
        agent.updatePosition = true;
        StartCoroutine(WaitAndGetRandomDest(waitSeconds));
    }

    
    void Update()
    {
        if (pathReached && target == null && !chasePlayer && !isCoroutineStarted)
        {
            StartCoroutine(WaitAndGetRandomDest(waitSeconds));
        }
        
        if (!pathReached && target != null && !chasePlayer)
        {
            agent.SetDestination(target.position);
        }
        if (chasePlayer)
        {
            target = player.transform;
            agent.SetDestination(target.position);
            pathReached = false;
        }
        /*if (target != null)
            agent.SetDestination(target.position);
        if (agent.remainingDistance > agent.stoppingDistance)
            character.Move(agent.desiredVelocity, false, false);
        else
            character.Move(Vector3.zero, false, false);*/
        
        AnimateAgent();
        HandleOffmeshLinkSpeed();
        IsReached();

    }

    private void FixedUpdate()
    {
        Raycasting();
        ChasePlayer();
    }

    private void IsReached()
    {
        if (!agent.pathPending && target != null)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                pathReached = true;
                target = null;
                
                Debug.Log("path reached is true");
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

    private void AnimateAgent()
    {
        if (agent.remainingDistance > agent.stoppingDistance && target != null)
            character.Move(agent.desiredVelocity, false, false);
        else
        {
            //I made this function to make the forward value zero
            character.StopWalkAnimation();
        }
    }

    IEnumerator WaitAndGetRandomDest(float waitsecs)
    {
        isCoroutineStarted = true;
        pathReached = false;
        yield return new WaitForSeconds(waitsecs);
        target = NpcDestManager.instance.getRandomDest().transform;
        
        isCoroutineStarted = false;
        Debug.Log("agent is going to " + target.name);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("player have been caught");
            playerIsCaught = true;
            chasePlayer = false;
        }

    }

    private void Raycasting()
    {
        RaycastHit hit;
        Vector3 rayForward = raycastFrom.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastFrom.transform.position, rayForward, Color.red, traceDistance);
        if (Physics.Raycast(raycastFrom.transform.position, rayForward, out hit, traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                print("Collided forward");
            }
        }

        Vector3 rayLeft = raycastFrom.transform.TransformDirection(Vector3.left);
        Debug.DrawRay(raycastFrom.transform.position, rayLeft, Color.red, traceDistance);
        if (Physics.Raycast(raycastFrom.transform.position, rayLeft, out hit, traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                print("Collided left");
            }
        }

        Vector3 rayRight = raycastFrom.transform.TransformDirection(Vector3.right);
        Debug.DrawRay(raycastFrom.transform.position, rayRight, Color.red, traceDistance);
        if (Physics.Raycast(raycastFrom.transform.position, rayRight, out hit, traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                print("Collided right");
            }
        }

        Vector3 rayBack = raycastFrom.transform.TransformDirection(Vector3.back);
        Debug.DrawRay(raycastFrom.transform.position, rayBack, Color.red, traceDistance);
        if (Physics.Raycast(raycastFrom.transform.position, rayBack, out hit, traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hitPlayer = true;
                print("Collided back");
            }
        }
    }

    private void ChasePlayer()
    {
        if (hitPlayer && !playerIsCaught)
        {
            chasePlayer = true;
        }
        
    }

}
