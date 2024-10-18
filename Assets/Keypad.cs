using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Keypad : MonoBehaviour
{
    public TextMeshProUGUI Answer;
    [SerializeField] private Door door; //Referencing the Door Script
    private string correctCode = "123456";

    private void Start()
    {
        Answer.text = ""; //This is to reset the answer at the beginning
    }

    public void Number (int number)
    {
        Answer.text += number.ToString();
    }

    public void Execute()
    {
        if(Answer.text == correctCode)
        {
            door.OpenDoor();
            Answer.text = ""; //Resets the text
        }
        else
        {
            Answer.text = ""; 
        }
    }
}
