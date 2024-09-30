using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTriggerScript : MonoBehaviour
{
    public bool nearComputer;

    private void OnTriggerEnter(Collider other)
    {
        var playerInput = new PlayerController();
        if (other.CompareTag("trigger"))
        {
            Debug.Log("Player near computer");
            nearComputer = true;
        }

        if (nearComputer == true)
        {
            playerInput.Player.Disable();
        }

        else
        {
            playerInput.Player.Enable();
        }
    }
}