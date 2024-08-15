using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    public GameObject playerObject;

    private FirstPersonController player;

    private void Start()
    {
        player = GetComponent<FirstPersonController>();

    }

    public void RespawnPlayer()
    {
        if (playerObject != null)
        {
            Debug.Log("Respawned");
            playerObject.transform.position = currentCheckpoint.transform.position;
        }
        else
        {
            Debug.LogError("Player reference is null in LevelManager");
        }
    }
}

