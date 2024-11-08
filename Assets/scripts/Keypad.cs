using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Text Answer;
    [SerializeField] private Animator Door; 
    private string correctCode = "123456";
    private KeypadTrigger trigger;
    private FirstPersonControls firstPersonControls;
    public GameObject player;

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
    }

    public void Number (int number)
    {
        Answer.text += number.ToString();
    }

    public void Execute()
    {
        if(Answer.text == correctCode)
        {
            Answer.text = "OPENED";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");
            EnablePlayerMovement();
        }
        else
        {
            Answer.text = ""; 
        }
    }

    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
        Door.SetBool("Open", false) ;
        Door.enabled = false ;
    }

    private void EnablePlayerMovement()
    {
        if (firstPersonControls != null)
        {
            firstPersonControls.enabled = true;
        }
    }

}
