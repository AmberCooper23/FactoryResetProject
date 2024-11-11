using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LetterScript : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;
    

    private FirstPersonControls firstPersonControls;
    public GameObject player;

    public AudioClip letterRead;
    private AudioSource audioSource;

    public bool isSpecialLetter = false;

    public string specialLetterTag = "letter";

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
        audioSource = GetComponent<AudioSource>();


        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource if it doesn't exist
        }

        
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

            if ((CompareTag(specialLetterTag) && letterRead != null))
             {
                PlayLetterSound();
            }
        }
    }

    public void PlayLetterSound()
    {
        if (audioSource != null && letterRead != null)
        {
            audioSource.PlayOneShot(letterRead);
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