using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamsForward : MonoBehaviour
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

            if (Physics.Raycast(transform.position, transform.up, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, hit.point);
                Debug.Log("Player collided");
                }
                else
            {
                Debug.Log("aint no collision chief");
            }
                if (hit.transform.tag == "Player")
                {
               //  Destroy(hit.transform.gameObject);
                levelManager.RespawnPlayer();
                Debug.Log("respawning like a bitch lmfao");
                }
               
        }
            else lr.SetPosition(1, transform.right * 5000);
        }
    }
