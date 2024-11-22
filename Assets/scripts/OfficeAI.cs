using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class OfficeAI : MonoBehaviour
{
    public Transform[] wayPoints;
    NavMeshAgent agent;
    int waypointIndex;
    Vector3 target;
    public bool isMoving = true;
    public GameObject bulletSound;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        UpdateDestination();
        
        bulletSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination(); 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("bullet hits AI");
            agent.enabled = false;
            isMoving = false;
            bulletSound.SetActive(true);
        }
    }

    void UpdateDestination() // Both
    {
        target = wayPoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex() // Both
    {
        waypointIndex++; 
        if(waypointIndex== wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
}

