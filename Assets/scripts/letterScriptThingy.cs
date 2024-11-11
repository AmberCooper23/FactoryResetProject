using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterScriptThingy : MonoBehaviour
{
    public GameObject letterRead;
    public GameObject letter;
    bool toggle;


    private FirstPersonControls firstPersonControls;
    public GameObject player;

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
    }

    public void Start()
    {
        letterRead.SetActive(false);
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
            letter.SetActive(false);
            EnablePlayerMovement();

        }
        if (toggle == true)
        {

            letter.SetActive(true);
            DisablePlayerMovement();
            letterRead.SetActive(true);



            letter.SetActive(true);
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
