using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    public GameObject playerObject;

    private FirstPersonController player;

    public CharacterController characterController;

    private void Start()
    {
        player = GetComponent<FirstPersonController>();
    }

    public void RespawnPlayer()
    {
        if (playerObject != null && currentCheckpoint != null)
        {
            Debug.Log("Respawn function called");

            CharacterController characterController = playerObject.GetComponent<CharacterController>();
            if (characterController != null)
                Debug.Log("Character controller component is there");
            {
                characterController.enabled = false;
                Debug.Log("Character controller is disabled");
            }

            playerObject.transform.position = currentCheckpoint.transform.position;
            Debug.Log("player position moved to checkpoint position");

            Rigidbody rb = playerObject.GetComponent<Rigidbody>();

            if (rb != null)
                Debug.Log("rb detected");
            {
                rb.velocity = Vector3.zero;
                Debug.Log("velocity reset");
                rb.angularVelocity = Vector3.zero;
                Debug.Log("angular velocity reset");
            }

            Debug.Log("Player respawned at: " + currentCheckpoint.transform.position);

            if (characterController != null)
                Debug.Log("Character controller detected again");
            {
                characterController.enabled = true;
                Debug.Log("Character controller enabled");
            }

        }
        else
        {
            Debug.LogError("Player reference is null in LevelManager");
        }
    }
}
