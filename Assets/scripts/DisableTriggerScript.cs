using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggerScript : MonoBehaviour
{
    public FirstPersonControls controller;
    public GameObject promptTrigger;

    public void DisableTrigger()
    {
        if (controller.hasCard)
        {
            Destroy(promptTrigger);
       }
    }
}
