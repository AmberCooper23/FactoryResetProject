using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerPrompts : MonoBehaviour
{
    public GameObject promptText;

    public void Start()
    {
        promptText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            promptText.SetActive(false);
        }
    }
}
