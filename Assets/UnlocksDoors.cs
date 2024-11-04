using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnlocksDoors : MonoBehaviour
{
    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector
    public Collider sirenOnTrigger;
    public GameObject unlockDoorTrigger;// Assign the trigger to disable
    public GameObject doorUnlocked;
    public GameObject unlockDoorTriggerText;
    // public GameObject keyCard;
    //  public bool hasCard;


    public FirstPersonControls fpController;

    private void Start()
    {
        // Ensure the initial state is set correctly
        sirenOnTrigger.enabled = true;
        unlockDoorTrigger.SetActive(true);   

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            if (fpController.hasCard)
            {
                TurnOffSiren();
                unlockDoorTrigger.SetActive(false);
                unlockDoorTriggerText.SetActive(false);
                StartCoroutine(ShowDoorUnlocked());
            }
            else
            {
                TurnOnSiren();
            }
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

    private IEnumerator ShowDoorUnlocked()
    {
        doorUnlocked.SetActive(true);
        yield return new WaitForSeconds(3);
        doorUnlocked.SetActive(false);
    }
}
