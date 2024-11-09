using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterScriptForKeycard : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;

    private FirstPersonControls firstPersonControls;
    public GameObject player;

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
}
