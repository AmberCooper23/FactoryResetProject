using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI messageText;


    private void Awake()
    {
        firstPersonControls = player.GetComponent<FirstPersonControls>();
    }

    public void Number(int number)
    {
        Answer.text += number.ToString();
    }

    public void Execute()
    {
        if (Answer.text == correctCode)
        {
            Answer.text = "OPENED";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");
            EnablePlayerMovement();
            CheckObjectTagAndDisplayMessage();
        }
        else
        {
            Answer.text = "";
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
    private void CheckObjectTagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        {
            messageText.text = "LOOK FOR THE WRENCH IN THE LOCKER ROOM";
        }

    }
}
