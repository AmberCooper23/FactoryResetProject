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
                SceneManager.LoadScene("SampleScene");
            }

        }
    }
}
