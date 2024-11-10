using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameStuff : MonoBehaviour
{
    public GameObject lenaPic;
    public Collider LaserTrigger; 

    public FirstPersonControls fpController;

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    public GameObject laser7;
    public GameObject laser8;
    public GameObject laser9;
    public GameObject laser10;
    public GameObject laser11;
    public GameObject laser12;
    public GameObject laser13;
    public GameObject laser14;
    public GameObject laser15;
    public GameObject laser16;


    private void Start()
    {
        LasersDeactivated();

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player"))) // Check if the collider has the specified tag
        {
            if (fpController.hasPhoto)
            {
                Debug.Log("EndGame Triggered");
                LasersActivated();
            }
            else
            {

               LasersDeactivated();
            }
        }
    }

    public void LasersActivated()
    {
        laser1.SetActive(true);
        laser2.SetActive(true);
        laser3.SetActive(true);
        laser4.SetActive(true);
        laser5.SetActive(true);
        laser6.SetActive(true);
        laser7.SetActive(true);
        laser8.SetActive(true);
        laser9.SetActive(true);
        laser10.SetActive(true);
        laser11.SetActive(true);
        laser12.SetActive(true);
        laser13.SetActive(true);
        laser14.SetActive(true);
        laser15.SetActive(true);
        laser16.SetActive(true);

    }
    public void LasersDeactivated()
    {
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        laser4.SetActive(false);
        laser5.SetActive(false);
        laser6.SetActive(false);
        laser7.SetActive(false);
        laser8.SetActive(false);
        laser9.SetActive(false);
        laser10.SetActive(false);
        laser11.SetActive(false);
        laser12.SetActive(false);
        laser13.SetActive(false);
        laser14.SetActive(false);
        laser15.SetActive(false);
        laser16.SetActive(false);
    }
}
