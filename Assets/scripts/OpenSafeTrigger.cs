using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafeTrigger : MonoBehaviour
{
    [SerializeField] private KeypadForSafe keypad;
    private FirstPersonControls firstPersonControls;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypad.gameObject.SetActive(true);
            DisablePlayerMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypad.gameObject.SetActive(false);
            keypad.AnswerForSafe.text = "";
        }
    }


    public void DisablePlayerMovement()
    {
        if (firstPersonControls != null)
        {
            firstPersonControls.enabled = false;
        }
    }

}
