using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    //[SerializeField] private Transform respawnPosition; // Position where the player should respawn
    //[SerializeField] private string playerTag = "Player"; // Tag used to identify the player
    public LevelManager levelManager;
  //  public GameObject player;

    // Called when another collider enters the trigger collider
    void OnCollisionEnter  (Collision other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the collider has the specified tag
        {
            Debug.Log("collided with killbox");
            // Respawn the player to the respawn position
           levelManager.RespawnPlayer(); // call the Respawn Player method from the Level Manager script
        }
    }
}
