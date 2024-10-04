using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private PlayerController playerInput;
    public Button[] mainMenuButtons;
    private int currentButtonIndex = 0;

    private void Awake()
    {
        playerInput = new PlayerController();
        playerInput.MainMenu.Enable();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Update()
    {
        Vector2 moveInput = playerInput.MainMenu.Navigation.ReadValue<Vector2>();

        if (moveInput.y > 0 || moveInput.y < 0)
        {
            NavigateMenu(moveInput);

        }

        if (playerInput.MainMenu.Select.triggered)
        {
            SelectButton();
        }

    }

    private void OnDisable()
    {
        playerInput.MainMenu.Disable();
    }
    public void NavigateMenu(Vector2 moveInput)
    {
        if (moveInput.y > 0)
        {
            currentButtonIndex--;

            if (currentButtonIndex < 0)
            {
                currentButtonIndex = mainMenuButtons.Length - 1;
            }
            else if (moveInput.y < 0)
            {
                currentButtonIndex++;

                if (currentButtonIndex >= mainMenuButtons.Length)
                    currentButtonIndex = 0;
            }

            UpdateButtonSelection();
        }
    }

    private void UpdateButtonSelection()
    {
        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            ColorBlock colors = mainMenuButtons[i].colors; // Get the button's colors
            colors.normalColor = (i == currentButtonIndex) ? Color.red : Color.white; // Highlight if selected
            mainMenuButtons[i].colors = colors;
        }
    }

    public void SelectButton()
    {
        mainMenuButtons[currentButtonIndex].onClick.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Sayonara Son!");
    }
}
