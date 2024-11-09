using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenSafeTrigger : MonoBehaviour
{
    [SerializeField] private KeypadForSafe keypad;
    private FirstPersonControls firstPersonControls;
    public GameObject player;
    public TextMeshProUGUI messageText;
    public GameObject objectToCheck;

    private void Start()
    {
        if(player != null)
        {
            firstPersonControls = player.GetComponent<FirstPersonControls>();
        }
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.X))
        {
            DisableKeypadAndEnableMovement();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypad.gameObject.SetActive(true);
            DisablePlayerMovement();
            CheckObjectTagAndDisplayMessage();
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

    public void EnablePlayerMovement()
    {
        if (firstPersonControls != null)
        {
            firstPersonControls.enabled = true; 
        }
    }

    public void DisableKeypadAndEnableMovement()
    {
        // Disable the keypad and re-enable player movement
        if (keypad != null)
        {
            keypad.gameObject.SetActive(false);
        }
        EnablePlayerMovement(); // Re-enable player movement
    }

    private void CheckObjectTagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        if (objectToCheck.CompareTag("SafeTrigger"))
        {
            messageText.text = "KEY WORD: ACTIVATION";
        }
    }
}
