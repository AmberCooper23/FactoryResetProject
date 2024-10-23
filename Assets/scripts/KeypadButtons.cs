using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButtons : MonoBehaviour
{
    private PlayerController playerInput;
    public Button[] keypadButtons;
    private int currentButtonIndex = 0;
    private Vector3[] originalScales;
    private int[,] navigationRules;

    public void Start()
    {
        playerInput = new PlayerController();
        playerInput.Keypad.Enable();

        originalScales = new Vector3[keypadButtons.Length];
        for (int i = 0; i < keypadButtons.Length; i++)
        {
            originalScales[i] = keypadButtons[i].transform.localScale;
        }

        navigationRules = new int[,]
       {
            { 1, 2, 3, 4 },  // From button 0: Up -> 1, Down -> 2, Left -> 3, Right -> 4
            { 0, 3, 4, 5 },  // From button 1: Up -> 0, Down -> 3, Left -> 4, Right -> 5
            { 1, 0, 5, 4 },  // From button 2: Up -> 1, Down -> 0, Left -> 5, Right -> 4
            { 2, 1, 0, 5 },  // From button 3: Up -> 2, Down -> 1, Left -> 0, Right -> 5
            { 0, 1, 2, 3 },  // From button 4: Up -> 0, Down -> 1, Left -> 2, Right -> 3
            { 2, 3, 1, 0 }   // From button 5: Up -> 2, Down -> 3, Left -> 1, Right -> 0
       }; 

        playerInput.Keypad.Up.performed += ctx => NavigateKeypad(0);
        playerInput.Keypad.Down.performed += ctx => NavigateKeypad(1);
        playerInput.Keypad.Left.performed += ctx => NavigateKeypad(2);
        playerInput.Keypad.Right.performed += ctx => NavigateKeypad(3);
        playerInput.Keypad.Select.performed += ctx => SelectButton();

        
    }

    private void OnDisable()
    {
        playerInput.Keypad.Disable();
    }
   
    public void NavigateKeypad(int direction)
    {
        currentButtonIndex = navigationRules[currentButtonIndex, direction];
        UpdateButtonSelection();
    }

    private void UpdateButtonSelection()
    {
        for (int i = 0; i < keypadButtons.Length; i++)
        {
            if (i == currentButtonIndex)
            {
                // Highlight the selected button by scaling it up
                keypadButtons[i].transform.localScale = originalScales[i] * 1.2f;
            }
            else
            {
                // Reset the scale for non-selected buttons
                keypadButtons[i].transform.localScale = originalScales[i];
            }
        }
    }

    public void SelectButton()
    {
        if(keypadButtons.Length > 0 && currentButtonIndex >= 0 && currentButtonIndex < keypadButtons.Length)
        {
            keypadButtons[currentButtonIndex].onClick.Invoke();
            Debug.Log("Button selected:" + keypadButtons[currentButtonIndex].name); 
        }
    }

}
