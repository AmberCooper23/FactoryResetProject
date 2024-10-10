using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   
    public bool Activated = false;
   
    public static List<GameObject> CheckPointsList;

    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

   
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().Activated = false;
        }

        // We activated the current checkpoint
        Activated = true;
    }

    void Start()
    {

        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint").ToList();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
}