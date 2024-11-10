using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class SirenController : MonoBehaviour
{
    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector
    public Collider sirenOnTrigger; // Assign the trigger to disable
    [SerializeField] private Animator switchHandle;

    // public GameObject keyCard;
    //  public bool hasCard;
    public GameObject objectToCheckSwitch;
    public TextMeshProUGUI messageText;

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
                //TurnOffSiren();
                emergencySiren.SetActive(false);
                textTrigger.SetActive(false);

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
        switchHandle.SetBool("SwitchOff", true);
        StartCoroutine("SwitchOffAlarm");

        CheckObjectTagAndDisplayMessage();

    }

    IEnumerator SwitchOffAlarm()
    {
        yield return new WaitForSeconds(1f);
        switchHandle.SetBool("SwitchOff", false);
        switchHandle.enabled = false;
    }

    private void CheckObjectTagAndDisplayMessage()
    {

        if (objectToCheckSwitch.CompareTag("Switch"))
        {
            messageText.text = "EXPLORE THE OFFICE FOR INFORMATION AND SUPPLIES";
        }


    }
}
