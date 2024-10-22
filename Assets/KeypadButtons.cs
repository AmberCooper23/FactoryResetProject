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
    private const float movementThreshold = 0.8f;

    public void Start()
    {
        playerInput = new PlayerController();
        playerInput.Keypad.Enable();
    }
    public void Update()
    {
        Vector2 moveInput = playerInput.Keypad.Navigate.ReadValue<Vector2>();

        if (moveInput.y > 0 || moveInput.y < 0)
        {
            NavigateKeypad(moveInput);
        }
    }

    public void NavigateKeypad(Vector2 moveInput)
    {
        if (Mathf.Abs(moveInput.y) > movementThreshold)
        {
            if (moveInput.y > 0)
            {
                currentButtonIndex--;

                if (currentButtonIndex < 0)
                {
                    currentButtonIndex = keypadButtons.Length - 1;
                }
                Debug.Log("Moved up, current button index: " + currentButtonIndex);
            }

            else if (moveInput.y < 0)
            {
                currentButtonIndex++;

                if (currentButtonIndex >= keypadButtons.Length)
                    currentButtonIndex = 0;

            }
            UpdateButtonSelection();
        }
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
        keypadButtons[currentButtonIndex].onClick.Invoke();
    }

}
