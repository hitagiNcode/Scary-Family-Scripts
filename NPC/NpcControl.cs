using System;
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
    public bool pathReached;
    public AudioSource m_audsource;
    public AudioClip violinAudio;
    public AudioSource chaseAudioLoop1;
    public GameObject[] disableAudios;
    public SingleDoor[] frontGates;

    //Privates
    public bool chasePlayer = false;
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    public ThirdPersonCharacter1 character { get; private set; }
    private float baseSpeed;
    
    private bool isCoroutineStarted = false;
    private float waitSeconds = 5f;
    private GameObject player;
    private bool playerIsCaught = false;
    private bool goScenePosition = false;
    private float traceDistance = 13f;
    private int unChaseDistance = 18;
    private bool playAudio = false;
    private bool borderCollided = false;

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
        
    }

    
    void Update()
    {
        if (target != null && !chasePlayer && goScenePosition)
        {
            agent.SetDestination(target.position);
        }

        if (pathReached && target == null && !chasePlayer && !isCoroutineStarted)
        {
            StartCoroutine(WaitAndGetRandomDest(waitSeconds));
        }
        if (!pathReached &&target==null &&!chasePlayer &&!isCoroutineStarted &&!goScenePosition)
        {
            StartCoroutine(WaitAndGetRandomDest(waitSeconds));
        }
        
        if (!pathReached && target != null && !chasePlayer)
        {
            agent.SetDestination(target.position);
        }
    
        
        AnimateAgent();
        HandleOffmeshLinkSpeed();
        IsReached();
        
    }

    private void FixedUpdate()
    {
        if (!chasePlayer && !borderCollided)
        {
            Raycasting();
        }
        ChasePlayer();
        UnchasePlayer();
    }

    private void UnchasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, raycastFrom.transform.position);

        if (chasePlayer)
        {
            if (distanceToPlayer > unChaseDistance || borderCollided)
            {
                target = null;
                agent.SetDestination(raycastFrom.transform.position);
                StopChaseAudio();
                Debug.Log("Unchasing playerr");
                chasePlayer = false;
            }
        }
        
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
            Debug.Log("player have been caught");
            playerIsCaught = true;
            chasePlayer = false;
        }
        if (other.gameObject.CompareTag("HouseBorder"))
        {
            
            borderCollided = true;
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HouseBorder"))
        {
            StartCoroutine(DelayedBorderCollider());
            for (int i = 0; i < frontGates.Length; i++)
            {
                frontGates[i].CloseGates();
            }
        }
    }

    private void Raycasting()
    {
        RaycastHit hit;
        Vector3 rayForward = raycastFrom.transform.TransformDirection(Vector3.forward) ;
        Debug.DrawRay(raycastFrom.transform.position, rayForward * traceDistance, Color.red);
        
        if (Physics.Raycast(raycastFrom.transform.position, rayForward, out hit,traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                chasePlayer = true;
                playAudio = true;
            }
        }

        Vector3 rayLeft = raycastFrom.transform.TransformDirection(Vector3.left) ;
        Debug.DrawRay(raycastFrom.transform.position, rayLeft * traceDistance, Color.green);
        if (Physics.Raycast(raycastFrom.transform.position, rayLeft, out hit,traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                chasePlayer = true;
                playAudio = true;
            }
        }

        Vector3 rayRight = raycastFrom.transform.TransformDirection(Vector3.right);
        Debug.DrawRay(raycastFrom.transform.position, rayRight *traceDistance, Color.blue);
        if (Physics.Raycast(raycastFrom.transform.position, rayRight, out hit,traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                chasePlayer = true;
                playAudio = true;
            }
        }

        Vector3 rayBack = raycastFrom.transform.TransformDirection(Vector3.back);
        Debug.DrawRay(raycastFrom.transform.position, rayBack * traceDistance, Color.yellow);
        if (Physics.Raycast(raycastFrom.transform.position, rayBack, out hit,traceDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                chasePlayer = true;
                playAudio = true;
            }
        }
    }

    private void ChasePlayer()
    {
        if (chasePlayer && !playerIsCaught)
        {
            target = player.transform;
            agent.SetDestination(target.position);
            pathReached = false;
            PlayChaseAudio();
        }
    }

    public void GoToScenePos(Transform posObj)
    {
        target = posObj;
        goScenePosition = true;
        
    }

    private void PlayChaseAudio()
    {
        if (playAudio)
        {
            m_audsource.PlayOneShot(violinAudio, 0.2f);
            chaseAudioLoop1.PlayDelayed(2f);
            for (int i = 0; i < disableAudios.Length; i++)
            {
                disableAudios[i].SetActive(false);
            }
            playAudio = false;
        }
    }
    private void StopChaseAudio()
    {
        chaseAudioLoop1.Stop();
        for (int i = 0; i < disableAudios.Length; i++)
        {
            disableAudios[i].SetActive(true);
        }
    }

    IEnumerator DelayedBorderCollider()
    {
        yield return new WaitForSeconds(2f);
        borderCollided = false;
    }

}
