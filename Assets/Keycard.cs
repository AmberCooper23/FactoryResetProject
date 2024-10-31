using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public GameObject KeycardUI;
    bool toggle;
    public PlayerController playerInput;
    private CharacterController characterController;


    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        playerInput = new PlayerController();

    }

    private void OnEnable()
    {

        var playerInput = new PlayerController();

        // Enable the input actions
        playerInput.Player.Enable();

        //playerInput.Player.Enable();
        playerInput.Player.Read.performed += ctx => openCloseLetter();

    }

    public void openCloseLetter()
    {

        Debug.Log("I want to open letter");
        toggle = !toggle;
        if (toggle == false)
        {
            KeycardUI.SetActive(false);
        }
        if (toggle == true)
        {
            KeycardUI.SetActive(true);
        }
    }
}
