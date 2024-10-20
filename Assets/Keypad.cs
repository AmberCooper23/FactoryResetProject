using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Text Answer;
    [SerializeField] private Animator Door; 
    private string correctCode = "123456";

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
}
