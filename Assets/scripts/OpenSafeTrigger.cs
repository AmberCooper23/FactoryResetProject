using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSafeTrigger : MonoBehaviour
{
    [SerializeField] private KeypadForSafe keypad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypad.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypad.gameObject.SetActive(false);
            keypad.AnswerForSafe.text = "";
        }
    }


}
