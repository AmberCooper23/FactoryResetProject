using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI; 

public class npcAI : MonoBehaviour
{
    public Transform[] wayPoints; 
    NavMeshAgent agent;
    int waypointIndex;
    Vector3 target;
    private bool isMoving = false; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing from the NPC.");
            return; 
        }

        agent.enabled = false; 

        if (wayPoints.Length > 0)
        {
            UpdateDestination(); 
        }
        else
        {
            Debug.LogError("Waypoints are not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving && agent.enabled)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
        }
    }

    void UpdateDestination()
    {
        if (wayPoints.Length == 0) return; 
        target = wayPoints[waypointIndex].position; 
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex = (waypointIndex + 1) % wayPoints.Length;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            agent.enabled = true; 
           isMoving = true;
        }
    }
}

