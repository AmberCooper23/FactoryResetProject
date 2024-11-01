using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScriptForKeycard : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;

    private void OnEnable()
    {

        //playerInput.Player.Enable();

    }

    public void openCloseLetter()
    {
        Debug.Log("Please open tuuuuuuu!");
        toggle = !toggle;
        if (toggle == false)
        {
            letterUI.SetActive(false);
        }
        if (toggle == true)
        {
            letterUI.SetActive(true);
        }
    }
}
