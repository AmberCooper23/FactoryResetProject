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
    private Vector3[] originalScales;
    private const float movementThreshold = 0.8f;
    public GameObject controlPage;
    public GameObject mainMenuPage;
    public string sceneToLoad;

  
    private void Awake()
    {
        playerInput = new PlayerController();
        playerInput.MainMenu.Enable();
        playerInput.Player.Disable();

        originalScales = new Vector3[mainMenuButtons.Length];
        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            originalScales[i] = mainMenuButtons[i].transform.localScale;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void ControlsScreen()
    {
        Debug.Log("controls pressed");
        controlPage.SetActive(true);
        mainMenuPage.SetActive(false);

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

        if (playerInput.MainMenu.Back.triggered)
        {
            BackButton();
        }
    }

    public void BackButton()
    {
        Debug.Log("Back pressed");
        controlPage.SetActive(false);
        mainMenuPage.SetActive(true);
    }

    public void NavigateMenu(Vector2 moveInput)
    {
        if (Mathf.Abs(moveInput.y) > movementThreshold)
        {
            if (moveInput.y > 0)
            {
                currentButtonIndex--;

                if (currentButtonIndex < 0)
                {
                    currentButtonIndex = mainMenuButtons.Length - 1;
                }
                Debug.Log("Moved up, current button index: " + currentButtonIndex);
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
            if (i == currentButtonIndex)
            {
                // Highlight the selected button by scaling it up
                mainMenuButtons[i].transform.localScale = originalScales[i] * 1.2f;
            }
            else
            {
                // Reset the scale for non-selected buttons
                mainMenuButtons[i].transform.localScale = originalScales[i];
            }
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
