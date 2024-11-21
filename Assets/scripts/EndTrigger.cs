using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;

    public void Start()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
}
