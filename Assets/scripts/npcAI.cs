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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) <1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = wayPoints[waypointIndex].position; 
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
