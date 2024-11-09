using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadForSafe : MonoBehaviour
{
    public Text AnswerForSafe;
    [SerializeField] private Animator Door;
    private string correctCode = "12178445";
    private FirstPersonControls firstPersonControls;
    public GameObject player;
    public GameObject keypadTrigger;

    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
    }

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
            EnablePlayerMovement();
            keypadTrigger.SetActive(false);
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

    private void EnablePlayerMovement()
    {
        if (firstPersonControls != null)
        {
            firstPersonControls.enabled = true;
        }
    }
}
