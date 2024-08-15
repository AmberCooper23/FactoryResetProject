using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamsForward : MonoBehaviour
{
    private LineRenderer lr;


        public Transform startPoint;


        private void Start()
        {
            lr = GetComponent<LineRenderer>();
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
                }
                if (hit.transform.tag == "Player")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
            else lr.SetPosition(1, transform.right * 5000);
        }
    }
