using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenController : MonoBehaviour
{
    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector
    public Collider sirenOnTrigger; // Assign the trigger to disable
    public Collider cardDropZone;

   // public GameObject keyCard;
  //  public bool hasCard;


    public FirstPersonControls fpController;

    private void Start()
    {
        // Ensure the initial state is set correctly
        sirenOnTrigger.enabled = true;
        cardDropZone.enabled = true;
        emergencySiren.SetActive(false);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
           
                TurnOnSiren();
          
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("KeyCard"))
        {
            TurnOffSiren();
            fpController.hasCard = false; // Set hasCard to false since the keycard is dropped
            Debug.Log("Keycard dropped. Siren is OFF.");
        }
    }


    public void TurnOnSiren()
    {
        emergencySiren.SetActive(true);
        Debug.Log("emergency siren ON");
    }

    public void TurnOffSiren()
    {
        emergencySiren.SetActive(false);
    }

   
}
