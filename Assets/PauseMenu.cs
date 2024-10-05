using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private PlayerController playerInput;
    public Button[] pauseMenuButtons;
    private int currentButtonIndex = 0;
    private Vector3[] originalScales;
    private const float movementThreshold = 0.8f;
    public GameObject controlPage;
    public GameObject pauseMenuPage;

    private bool isPaused = false;

    private void Awake()
    {
        playerInput = new PlayerController();
        playerInput.PauseMenu.OpenPauseMenu.performed += ctx => TogglePause();
        playerInput.PauseMenu.Enable();
        playerInput.Player.Disable();
        playerInput.MainMenu.Disable();

        originalScales = new Vector3[pauseMenuButtons.Length];
        for (int i = 0; i < pauseMenuButtons.Length; i++)
        {
            originalScales[i] = pauseMenuButtons[i].transform.localScale;
        }
    }


    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlsScreen()
    {
        Debug.Log("controls pressed");
        controlPage.SetActive(true);
        pauseMenuPage.SetActive(false);

    }

    public void Update()
    {
        if (isPaused) return; 

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
        pauseMenuPage.SetActive(true);
        Resume(); 
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
                    currentButtonIndex = pauseMenuButtons.Length - 1;
                }
                Debug.Log("Moved up, current button index: " + currentButtonIndex);
            }

            else if (moveInput.y < 0)
            {
                currentButtonIndex++;

                if (currentButtonIndex >= pauseMenuButtons.Length)
                    currentButtonIndex = 0;

            }
            UpdateButtonSelection();
        }
    }

    private void UpdateButtonSelection()
    {
        for (int i = 0; i < pauseMenuButtons.Length; i++)
        {   
            if (i == currentButtonIndex)
            {
                // Highlight the selected button by scaling it up
                pauseMenuButtons[i].transform.localScale = originalScales[i] * 1.2f;
            }
            else
            {
                // Reset the scale for non-selected buttons
                pauseMenuButtons[i].transform.localScale = originalScales[i];
            }
        }
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenuPage.SetActive(true);
        Time.timeScale = 0; 
        playerInput.Player.Disable();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    public void SelectButton()
    {
        pauseMenuButtons[currentButtonIndex].onClick.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Sayonara Son!");
    }

    public void AreYouSureScreen()
    {

    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Resume(); 
        }
        else
        {
            Pause(); 
        }
    }
}
