using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleActivation : MonoBehaviour
{
    [SerializeField] private Animator console;
    //public AnimationClip button01;
    //public AnimationClip button02;


    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            console.SetBool("activation", true);
            StartCoroutine("ConsoleGoingUp");
        }
        
    }

    IEnumerator ConsoleGoingUp()
    {
        yield return new WaitForSeconds(0.5f);
        console.SetBool("Open", false);
        console.enabled = false;
    }

    //public void consoleMovement()
    //{
    //    consoleUp.Play();
    //}
    //private void EnablePlayerMovement()
    //{
    //    if (firstPersonControls != null)
    //    {
    //        firstPersonControls.enabled = true;
    //    }
    //}


}
