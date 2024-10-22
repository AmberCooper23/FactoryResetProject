//using System.Collections;
//using System.Collections.Generic;
//using JetBrains.Annotations;
//using 
//using UnityEditor.ShaderGraph;
//using UnityEditor.ShaderGraph.Drawing;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FirstPersonControls : MonoBehaviour
{
    public Transform Hinge;
    public Transform Hinge2;
    private bool Open;
    private bool OpenDoor2;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    public GameObject playerPickUp;
    
    bool toggle;

    private PlayerController playerInput;

    public bool hasCard = false;


    [Header("MOVEMENT SETTINGS")]
    [Space(5)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
    public Transform playerCamera; // Reference to the player's camera
                                   // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    public Vector2 lookInput; // Stores the look input from the player
    private float verticalLookRotation = 0f; // Keeps track of vertical camera rotation for clamping
    private Vector3 velocity; // Velocity of the player
    private CharacterController characterController; // Reference to the CharacterController component
    public float sprintSpeed = 5f; 

    [Header("SHOOTING SETTINGS")]
    [Space(5)]
    public GameObject projectilePrefab; // Projectile prefab for shooting
    public Transform firePoint; // Point from which the projectile is fired
    public float projectileSpeed = 20f; // Speed at which the projectile is fired
    public float pickUpRange = 3f; // Range within which objects can be picked up
    private bool holdingGun = false;

    [Header("PICKING UP SETTINGS")]
    [Space(5)]
    public Transform holdPosition; // Position where the picked-up object will be held
    private GameObject heldObject; // Reference to the currently held object

    // Crouch settings
    [Header("CROUCH SETTINGS")]
    [Space(5)]
    public float crouchHeight = 2f; // Height of the player when crouching
    public float standingHeight = 3.41f; // Height of the player when standing
    public float crouchSpeed = 2.5f; // Speed at which the player moves when crouching
    private bool isCrouching = false; // Whether the player is currently crouching

    [Header("INTERACT SETTINGS")]
    [Space(5)]
    public Material switchMaterial; // Material to apply when switch is activated
    public GameObject[] objectsToChangeColor; // Array of objects to change color

    [Header("COMPUTER INTERACTIONS")]
    [Space(5)]
    public string sceneToLoad;
    public bool nearComputer = false;

    [Header("Anim checks")]
    [Space(5)]

    public bool Iswalking;
    public bool IsCrouching; 

    //[Header("ANIMATION SETTINGS")]
    //[Space(5)]
    public Animator animator; //Reference to the Animator component 


    public GameObject pausePage;
    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        playerInput = new PlayerController();

        pauseMenuUI.SetActive(false);

    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new PlayerController();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.Look.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        playerInput.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed

        // Subscribe to the shoot input event
        playerInput.Player.Shoot.performed += ctx => Shoot(); // Call the Shoot method when shoot input is performed

        // Subscribe to the pick-up input event
        playerInput.Player.PickUp.performed += ctx => PickUpObject(); // Call the PickUpObject method when pick-up input is performed

        // Subscribe to the crouch input event
        playerInput.Player.Crouch.performed += ctx => ToggleCrouch(); // Call the ToggleCrouch method when crouch input is performed

        // Subscribe to the interact input event
        playerInput.Player.Interact.performed += ctx => Interact(); // Interact with switch

        playerInput.Player.Sprint.performed += ctx => Sprinting();

        playerInput.Player.Sprint.canceled += ctx => SprintingStopped(); 

        playerInput.Player.Sprint.canceled += ctx => Walking();

        playerInput.Player.SwitchMap.performed += ctx => SwitchActionMap();

        playerInput.PauseMenu.OpenPauseMenu.performed += ctx => Pause();

        playerInput.MainMenu.Back.performed += ctx => BackButton();

        playerInput.Player.Pause.performed += ctx => PauseGame();

       

    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }


    private void Update()
    {
        // Call Move and LookAround methods every frame to handle player movement and camera rotation
        Move();
        LookAround();
        ApplyGravity();

/*        Debug.Log(transform.position);

        if (Open && Hinge.rotation.y < 0.9f)
        {
            Hinge.Rotate(0, 140 * Time.deltaTime, 0);
        }
        else if (Hinge.rotation.y > 0.9f)
        {
            Open = false;
        }
        Debug.Log(Hinge.rotation.y);

        if(OpenDoor2 && Hinge2.rotation.y < 0.9f)
        {
            Hinge2.Rotate(0, 140 * Time.deltaTime, 0);
        }
        else if (Hinge2.rotation.y > 0.9f)
        {
            OpenDoor2 = false;
        }
        Debug.Log(Hinge2.rotation.y);*/

        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        /*if (hit.collider.gameObject.CompareTag("Step"))
        {
            Open = true;
        }

        if (hit.collider.gameObject.CompareTag("Clap"))
        {
            OpenDoor2 = true; 
        }*/
    }


    public void Move()
    {
        // Create a movement vector based on the input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // Transform direction from local to world space
        move = transform.TransformDirection(move);

        // Adjust speed if crouching
        float currentSpeed;
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }


        if (moveInput.x == 0 && moveInput.y == 0)
        {
            currentSpeed = 0;
            Iswalking = false;  
            animator.SetBool("IsWalking",false);
        }
        else
        {
            currentSpeed = moveSpeed;
            Iswalking = true;
            animator.SetBool("IsWalking", true);
        }

        // Move the character controller based on the movement vector and speed
        characterController.Move(move * currentSpeed * Time.deltaTime);
        //animator.SetFloat("Speed", currentSpeed); //Update the speed parameter in the Animator 
    }

    public void WalkCheck() 
    { 
       
    }

    
    public void PauseGame()
    {
       playerInput.Player.Disable();
        playerInput.PauseMenu.Enable();
        pauseMenuUI.SetActive(true);
    }

    public void ResumeScreen()
    {
        playerInput.MainMenu.Disable();
       playerInput.Player.Enable();
        pauseMenuUI.SetActive(false);
    }
    public void BackButton()
    {

    }
    public void SwitchActionMap()
    {
        playerInput.Player.Disable();
        playerInput.Computer.Enable();
    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LookAround()
    {
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        // Horizontal rotation: Rotate the player object around the y-axis
        transform.Rotate(0, LookX, 0);

        // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
        verticalLookRotation -= LookY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Apply the clamped vertical rotation to the player camera
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Small value to keep the player grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        characterController.Move(velocity * Time.deltaTime); // Apply the velocity to the character
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            // Calculate the jump velocity
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Shoot()
    {
        if (holdingGun == true)
        {
            // Instantiate the projectile at the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody component of the projectile and set its velocity
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;

            // Destroy the projectile after 3 seconds
            Destroy(projectile, 3f);
        }
    }

    public void PickUpObject()
    {
        // Check if we are already holding an object
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
            heldObject.transform.parent = null;
            holdingGun = false;
        }

        // Perform a raycast from the camera's position forward
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);


        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            // Check if the hit object has the tag "PickUp"
            if (hit.collider.CompareTag("PickUp"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;
            }
            else if (hit.collider.CompareTag("Gun"))
            {
                // Pick up the object
                Debug.Log("pick gun");
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                holdingGun = true;
            }

            else if (hit.collider.CompareTag("KeyCard"))
            {
                Debug.Log("got keycard");
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                hasCard = true;
            }
        }
    }

    public void ToggleCrouch()
    {
        if (isCrouching)
        {
            // Stand up
            characterController.height = standingHeight;
            isCrouching = false;
            animator.SetBool("IsCrouching", false);
        }
        else
        {
            // Crouch down
            characterController.height = crouchHeight;
            isCrouching = true;
            animator.SetBool("IsCrouching", true); 
        }
    }

    public void Sprinting()
    {
        moveSpeed = +5; 
    }

    public void SprintingStopped()
    {
        moveSpeed = -5; 
    }

    public void Walking()
    {
        moveSpeed = 4; 
    }

    public void Interact()
    {
        // Perform a raycast to detect the lightswitch
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Switch")) // Assuming the switch has this tag
            {
                // Change the material color of the objects in the array
                foreach (GameObject obj in objectsToChangeColor)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = switchMaterial.color; // Set the color to match the switch material color
                    }
                }
            }

            else if (hit.collider.CompareTag("Door")) // Check if the object is a door
            {
                // Start moving the door upwards
                StartCoroutine(SlideDoor(hit.collider.gameObject));
            }

            else if (hit.collider.CompareTag("Door2"))
            {

            }
        }
    }

    private IEnumerator SlideDoor(GameObject door)
    {
        float slideAmount = 8f; // The total distance the door will be raised
        float slideSpeed = 2f; // The speed at which the door will be raised
        Vector3 startPosition = door.transform.position; // Store the initial position of the door
        Vector3 endPosition = startPosition + (Vector3.up * slideAmount); // Calculate the final position of the door after raising

        // Continue raising the door until it reaches the target height
        while (door.transform.position.y < endPosition.y)
        {
            // Move the door towards the target position at the specified speed
            door.transform.position = Vector3.MoveTowards(door.transform.position, endPosition, slideSpeed * Time.deltaTime);
            yield return null; // Wait until the next frame before continuing the loop
        }
    }

    

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}



    //private void ComputerInteract()
    //{
    //    if (!string.IsNullOrEmpty(sceneToLoad))
    //    {
    //        SceneManager.LoadScene(sceneToLoad);  // Load the specified scene
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Scene name is not set.");
    //    }
    //}

}
