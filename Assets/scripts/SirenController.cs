using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenController : MonoBehaviour
{
    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector
    public Collider triggerToDisable; // Assign the trigger to disable
    public Collider triggerToEnable;  // Assign the trigger to enable

    private void Start()
    {
        // Ensure the initial state is set correctly
        EnableTriggers(true);
    }

    public void TurnOffSiren()
    {
        // Disable the siren
        emergencySiren.SetActive(false);

        // Switch triggers
        EnableTriggers(false);
    }

    private void EnableTriggers(bool enable)
    {
        triggerToDisable.enabled = enable; // Enable or disable the first trigger
        triggerToEnable.enabled = !enable; // Enable the second trigger if the first is disabled
    }
}
