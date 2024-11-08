using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    [SerializeField] private Keypad keypad;
    private FirstPersonControls firstPersonControls;
    public GameObject player; 

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
            keypad.Answer.text = "";
        }
    }

    public void DisablePlayerMovement()
    {
        if(firstPersonControls != null)
        {
            firstPersonControls.enabled = false;    
        }
    }


}
