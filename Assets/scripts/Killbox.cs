using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    //[SerializeField] private Transform respawnPosition; // Position where the player should respawn
    //[SerializeField] private string playerTag = "Player"; // Tag used to identify the player
    public LevelManager levelManager;
    //  public GameObject player;

    public GameObject currentCheckpoint;

    public GameObject playerObject;

    private FirstPersonController player;


    // Called when another collider enters the trigger collider

    private void Start()
    {
        player = GetComponent<FirstPersonController>();

    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            Debug.Log("collided with killbox");
            // Respawn the player to the respawn position
            levelManager.RespawnPlayer();
        }
    }
}
