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

    public AudioSource letterReading;
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
           if (CompareTag ("Letter"))
            {
                letterUI.SetActive(true);
                DisablePlayerMovement();
                letterReading.Play();

            }
           else
            {
               letterUI.SetActive(true);
               DisablePlayerMovement();
                letterReading.Pause();
            }
            

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