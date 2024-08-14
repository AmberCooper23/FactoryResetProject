using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Killbox : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition; // Position where the player should respawn
    [SerializeField] private string playerTag = "Player"; // Tag used to identify the player

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) // Check if the collider has the specified tag
        {
            // Respawn the player to the respawn position
            other.transform.position = respawnPosition.position;
            // Optionally, reset the player's velocity or other states here if needed
        }
    }
}
