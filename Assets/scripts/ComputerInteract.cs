using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerInteract : MonoBehaviour
{
    [SerializeField]
    public GameObject[] displays;


    private int currentDisplayIndex = 0;

    private PlayerController controls;

    private FirstPersonControls firstPersonControls;

    private void Awake()
    {
        controls = new PlayerController();


        controls.Computer.DisplayControls.performed += ctx => HandleDisplayControls(ctx.ReadValue<Vector2>()); // Update moveInput when movement input is performed

    }

    public void Start()
    {
        for (int i = 0; i < displays.Length; i++)
        {
            displays[i].SetActive(false);
        }

        if (displays.Length > 0)
        {
         displays[currentDisplayIndex].SetActive(true);

        }
    }

    private void Update()
    {
        if (firstPersonControls != null && firstPersonControls.nearComputer == true)
        {
            OnEnable();
        }
        else
        {
            OnDisable();
        }
    }
    private void OnEnable()
    {
        controls.Computer.Enable();

    }

    private void OnDisable()
    {
        controls.Computer.Disable();
    }

    private void HandleDisplayControls(Vector2 value)
    {
        if (value.x < 0)
        {
            MoveToPreviousDisplay();
        }
        else if (value.x > 0)
        {
            MoveToNextDisplay();
        }
    }

    public void MoveToNextDisplay()
    {
        if (displays.Length == 0) return;
        
            displays[currentDisplayIndex].SetActive(false);

            currentDisplayIndex = (currentDisplayIndex + 1) % displays.Length;

            displays[currentDisplayIndex].SetActive(true);

        Debug.Log($"Moved to next display: {currentDisplayIndex}");

    }

    public void MoveToPreviousDisplay()
    {
        if (displays.Length == 0) return;

        displays[currentDisplayIndex].SetActive(false);

        currentDisplayIndex = (currentDisplayIndex - 1) % displays.Length;

        displays[currentDisplayIndex].SetActive(true);

        Debug.Log($"Moved to prev display: {currentDisplayIndex}");
    }
}
