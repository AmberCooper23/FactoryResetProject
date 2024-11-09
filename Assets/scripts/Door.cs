using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform Hinge;
    public float openAngle;
    private bool open;
    public TextMeshProUGUI messageText;
    public GameObject objectToCheck;

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
        CheckObjectTagAndDisplayMessage();
    }
    public void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        Debug.Log("Opening");
        Hinge.Rotate(0, openAngle, 0);
    }

    public void CloseDoor()
    {
        Debug.Log("closing");
        Hinge.Rotate(0, -openAngle, 0);
    }

    private void CheckObjectTagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        if (objectToCheck.CompareTag("Dzoouh"))
        {
            messageText.text = "FIND THE KEYCODE TO UNLOCK THE LOCKER ROOM";
        }
    }

}
