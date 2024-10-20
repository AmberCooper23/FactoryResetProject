using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadForSafe : MonoBehaviour
{
    public Text AnswerForSafe;
    [SerializeField] private Animator Door;
    private string correctCode = "2683111";

    public void Number(int number)
    {
        AnswerForSafe.text += number.ToString();
    }

    public void Execute()
    {
        if (AnswerForSafe.text == correctCode)
        {
            AnswerForSafe.text = "OPENED";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");
        }
        else
        {
            AnswerForSafe.text = "";
        }
    }

    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
        Door.SetBool("Open", false);
        Door.enabled = false;
    }
}
