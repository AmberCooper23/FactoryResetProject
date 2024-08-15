using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    private LineRenderer lr;

    
    public Transform startPoint;
    public LevelManager levelManager;


    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        levelManager = FindObjectOfType<LevelManager>();

    }


    void Update()
    {

        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
                Debug.Log("Get collided motherfucker"); // laser is being stopped by the wall
            }
            else
            {
                Debug.Log("you hallucinated the collision");
            }
            if (hit.transform.tag == "Player")
            {
              // Destroy(hit.transform.gameObject);
                levelManager.RespawnPlayer();
                Debug.Log("respawn like a bitch");
            }
           
        }
        else lr.SetPosition(1, transform.right * 5000);
    }
}