using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Keypad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Ans;
    private Door Door;
    private string Answer = "123456"; 
    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute ()
    {
        if(Ans.text == Answer)
        {
           Door.OpenDoor();
        }
        else
        {
            Door.CloseDoor();
        }
    }
}
