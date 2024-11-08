using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerpromptstwo : MonoBehaviour
{
    
        public GameObject promptText;
        public GameObject promptTrigger;

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
        if (other.CompareTag("Player"))
        {
            promptText.SetActive(false);
            
        }
    }

}
