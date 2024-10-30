using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class ComputerScriptThing : MonoBehaviour
{
    public VideoPlayer videoClip;
    public AudioSource audioThing;

    private void Start()
    {
        videoClip.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NearComputer();
        }
    }

    void NearComputer()
    {
        videoClip.Play();
    }
    void Update()
    {
        
    }
}
