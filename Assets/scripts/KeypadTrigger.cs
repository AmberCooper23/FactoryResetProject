using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    [SerializeField] private Keypad keypad;
    private FirstPersonControls firstPersonControls;
    public GameObject player;
    public GameObject objectToCheck;
    public TextMeshProUGUI messageText;

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>(); 
    }

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
            keypad.answer.text = "";
            CheckObjectTagAndDisplayMessage(); 
        }
    }

    public void DisablePlayerMovement()
    {
        if(firstPersonControls != null)
        {
            firstPersonControls.enabled = false;    
        }
    }


    private void CheckObjectTagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        if (objectToCheck.CompareTag("SafeTrigger"))
        {
            messageText.text = "PRESS X KEY TO EXIT KEYPAD";
        }
    }

}
