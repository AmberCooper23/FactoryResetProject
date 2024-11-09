using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterScriptwPrompts : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;
    public TextMeshProUGUI messageText;

    private FirstPersonControls firstPersonControls;
    public GameObject player;
    public GameObject objectToCheck;

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
    }

    private void OnEnable()
    {

        //playerInput.Player.Enable();

    }

    public void openCloseLetter()
    {
        Debug.Log("Please open tuuuuuuu!");
        toggle = !toggle;
        if (toggle == false)
        {
            letterUI.SetActive(false);
            EnablePlayerMovement();

            CheckObjectTagAndDisplayMessage();

        }
        if (toggle == true)
        {
            letterUI.SetActive(true);
            DisablePlayerMovement();

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

    private void CheckObjectTagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        if (objectToCheck.CompareTag("StickyNote"))
        {
            messageText.text = "PUT IN THE KEYCODE FOR THE LOCKER ROOM";
        }
        else if (objectToCheck.CompareTag("Activation"))
        {
            messageText.text = "YOU HAVE FOUND THE SAFE KEYCODE. YOU MAY NOW UNLOCK THE SAFE";
        }
    }
}
