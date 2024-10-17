using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Keypad Keypad;
    public Transform Hinge;
    public float openAngle;
    private bool isOpen = false;
    [SerializeField] private TextMeshProUGUI Ans;
    private string Answer = "123456";
    public GameObject Keycode; 

    private void OnTriggerEnter(Collider other)
    {
        Keycode.SetActive(true); 

        if (Ans.text == Answer && !isOpen)
        {
            OpenDoor();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Keycode.SetActive(false); 
        CloseDoor();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            Debug.Log("Opening");
            Hinge.Rotate(0, openAngle, 0);
            isOpen = true;
        }
        
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            Debug.Log("Closing");
            Hinge.Rotate(0, -openAngle, 0);
            isOpen = false; 
        }
    }



}
