using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public GameObject Platform1, Platform2, Platform3, Platform4, RespawnPlatform1, RespawnPlatform2, RespawnPlatform3, RespawnPlatform4;
    //[SerializeField] private Transform respawnPosition; // Position where the player should respawn
    //[SerializeField] private string playerTag = "Player"; // Tag used to identify the player
    public LevelManager levelManager;
    //  public GameObject player;

    public GameObject currentCheckpoint;

    public GameObject playerObject;

    private FirstPersonController player;

    public GameObject redScreenUI;

 
    // Called when another collider enters the trigger collider

    private void Start()
    {
        player = GetComponent<FirstPersonController>();
       
        Platform1.SetActive(true);
        Platform2.SetActive(true);
        Platform3.SetActive(true);
        Platform4.SetActive(true);
        RespawnPlatform1.SetActive(false);
        RespawnPlatform2.SetActive(false);
        RespawnPlatform3.SetActive(false);
        RespawnPlatform4.SetActive(false);

        redScreenUI.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            redScreenUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            Debug.Log("collided with killbox");
            // Respawn the player to the respawn position
            levelManager.RespawnPlayer();

            Platform1.SetActive(false);
            Platform2.SetActive(false);
            Platform3.SetActive(false);
            Platform4.SetActive(false);
            RespawnPlatform1.SetActive(true);
            RespawnPlatform2.SetActive(true);
            RespawnPlatform3.SetActive(true);
            RespawnPlatform4.SetActive(true);


        }
    }
}
