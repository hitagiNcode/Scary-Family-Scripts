using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSight : MonoBehaviour
{
    public float SightAngle = 360f;
    public float sightRange = 12f;
    public bool playerInSight;
    public GameObject raycastObj;
    
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Raycast()
    {
        playerInSight = false;
        

        Vector3 direction = player.transform.position - raycastObj.transform.position;
        float angle = Vector3.Angle(direction, raycastObj.transform.forward);

        if (angle < SightAngle * 0.5f)
        {
            Debug.DrawRay(raycastObj.transform.position, direction.normalized * sightRange, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(raycastObj.transform.position, direction.normalized, out hit, sightRange))
            {
                if (hit.collider.gameObject == player)
                {
                    
                    playerInSight = true;
                }
                
            }
        }


    }
}
