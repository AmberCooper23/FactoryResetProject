using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpText : MonoBehaviour
{
    private bool toggle;
    public GameObject playerPickUpObject;  
    public void PickUps()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            playerPickUpObject.SetActive(false);
        }

        if (toggle == true)
        {
            playerPickUpObject.SetActive(true);
        }
    }
}
