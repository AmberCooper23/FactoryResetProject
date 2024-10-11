using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenController : MonoBehaviour
{
    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector
    public Collider sirenOnTrigger; // Assign the trigger to disable

   // public GameObject keyCard;
  //  public bool hasCard;


    public FirstPersonControls fpController;

    public GameObject textTrigger;
    private void Start()
    {
        // Ensure the initial state is set correctly
        sirenOnTrigger.enabled = true;
        emergencySiren.SetActive(false);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            if (fpController.hasCard)
            {
                TurnOffSiren();
                textTrigger.SetActive(false );
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

    //public void HoldingCard()
    //{
    //    if(fpController.hasCard == true && triggerToDisable != null)
    //    {

    //    }
    //}

    //public void TurnOffSiren(FirstPersonController fpController)
    //{
    //    // call a game object for keycard (referencing) , need bool for hasCard , if (bool hasCard == true && OnTriggerEnter triggerToDisable) 

    //    if (hasCard = true && triggerToDisable != null)
    //    {
    //        // Disable the siren
    //        emergencySiren.SetActive(false);
    //        // Switch triggers
    //       triggerToEnable.enabled = false;
    //        triggerToDisable.enabled = true;
    //    }
    //}   
}
