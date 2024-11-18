//using System.Collections;
//using System.Collections.Generic;
//using JetBrains.Annotations;
//using 
//using UnityEditor.ShaderGraph;
//using UnityEditor.ShaderGraph.Drawing;
using System;
using System.Collections;
using System.ComponentModel.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class FirstPersonControls : MonoBehaviour
{
    public Transform Hinge;
    public Transform Hinge2;
    private bool Open;
    private bool OpenDoor2;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    AudioSource audioSource;

    public GameObject emergencySiren; // Assign the siren GameObject in the Inspector

    public SirenController sirenController;

    public GameObject playerPickUp;

    bool toggle;

    public PlayerController playerInput;

    public bool hasCard = false;

    public bool hasPhoto = false; 

    private LetterScript letterScript;

    public GameObject promptTriggers;

    public GameObject doorLock;

    public TextMeshProUGUI messageText;

    public GameObject objectToCheck;

    public GameObject objectToCheckSwitch;

    public GameObject objectCheckGun;

    public GameObject objectCheckDoor2;

    public GameObject objectCheckWrench;

    public GameObject objectTrigger;

    public GameObject welcomeText;

    public GameObject lenaPhoto;

    public GameObject cityDestroy;

    public GameObject factoryDestroy;

    public GameObject switchOff;

    public GameObject video1;
    public GameObject video2;


    [SerializeField] private Animator ConsoleAnimation;
    [Header("Camera")]
    public Camera cam; 


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
    public float pickUpRange = 15f; // Range within which objects can be picked up
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

    [Header("AUDIO IMPORTS")]
    [Space(5)]
    public AudioSource walkingClip;

    public GameObject pickUpClip;
    public GameObject dropClip;
    public GameObject switchOffTheEmergencySiren;
    public GameObject exploreTheOfficeAudio;
    public GameObject lookAroundForLenaPicAudio;
    public GameObject proceedToUnlockAudio;
    public GameObject dropWrenchAudio;
    public GameObject welcomeAudio;
    public GameObject finalDecisionAudio;
    public GameObject switchOffSirenAudio;

    //public AudioSource computerClip;

    [Header("LIGHT SWITCH VARIABLES")]
    [Space(5)]
    public bool lightOn = false;
    public LightSwitchScript lightSwitchScript;

    [Header("ANIM CHECKS")]
    [Space(5)]

    public bool isWalking;
    public bool IsCrouching;
    public bool isJumping;
    public bool isSideWalking;
    public bool isCrouchWalking; 


    //[Header("ANIMATION SETTINGS")]
    //[Space(5)]
    public Animator animator; //Reference to the Animator component 


    public GameObject pausePage;
    private void Awake()
    {
        // Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        playerInput = new PlayerController();
        audioSource = GetComponent<AudioSource>();

        pauseMenuUI.SetActive(false);

    }

    public void Start()
    {
        pickUpClip.SetActive(false);
        dropClip.SetActive(false);
        switchOffTheEmergencySiren.SetActive(false);
        exploreTheOfficeAudio.SetActive(false);
        lookAroundForLenaPicAudio.SetActive(false);
        proceedToUnlockAudio.SetActive(false);
        dropWrenchAudio.SetActive(false);
        welcomeAudio.SetActive(false);
        finalDecisionAudio.SetActive(false);
        switchOffSirenAudio.SetActive(false);
        video1.SetActive(false);
        video2.SetActive(false);

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

        playerInput.Player.CrouchWalk.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); 

        playerInput.Player.SwitchMap.performed += ctx => SwitchActionMap();

        playerInput.PauseMenu.OpenPauseMenu.performed += ctx => Pause();

        playerInput.MainMenu.Back.performed += ctx => BackButton();

        playerInput.Player.Pause.performed += ctx => PauseGame();


        
    }

    private void OnDisable()
    {
        //playerInput.Player.Disable();
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
            isWalking = false;  
            animator.SetBool("isWalking",false);
            walkingClip.Play();

        }
        else
        {
            currentSpeed = moveSpeed;
            isWalking = true;
            animator.SetBool("isWalking", true);
           
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
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        else
        {
            isJumping=false;
            animator.SetBool("isJumping", false);
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
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 15f);


        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            //pickUpClip.Play();
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

                CheckWrenchAndDisplayMessage();
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

                CheckGunAndDisplayMessage();
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

                CheckKeycardAndDisplayMessage();
            }

            else if (hit.collider.CompareTag("LenaPic"))
            {
                Debug.Log("Retrieved Lena's Photo");
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                hasPhoto = true;
                Debug.Log("hasPhoto = true");

                CheckPhotoAndDisplayMessage();


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
            animator.SetBool("isCrouching", false);
        }
        else
        {
            // Crouch down
            characterController.height = crouchHeight;
            isCrouching = true;
            animator.SetBool("isCrouching", true); 
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
                doorLock.SetActive(false); 
                promptTriggers.SetActive(false); 
               sirenController.TurnOffSiren();
                sirenController.sirenOnTrigger.enabled = false;
                

                Debug.Log("Siren switched off");

                CheckSwitchTagAndDisplayMessage();
            }

            else if (hit.collider.CompareTag("Door")) // Check if the object is a door
            {
                // Start moving the door upwards
                StartCoroutine(SlideDoor(hit.collider.gameObject));
            }

            else if (hit.collider.CompareTag("Door2"))
            {
                StartCoroutine(SlideDoor(hit.collider.gameObject));
                CheckDoor2TagAndDisplayMessage();

            }
            else if (hit.collider.CompareTag("LightSwitch"))
            {
                lightSwitchScript.ToggleLight();
            }
            else if (hit.collider.CompareTag("Bookshelf"))
            {
                ConsoleAnimation.SetBool("FinalBoss", true);
                StartCoroutine("BringUpControlPanel"); 
            }
            else if (hit.collider.CompareTag("CityDestroy"))
            {
                video1.SetActive(true);
                video2.SetActive(false);
            }

            else if (hit.collider.CompareTag("FactoryDestroy"))
            {
                video1.SetActive(false);
                video2.SetActive(true);
            }

           
            //else if (hit.collider.CompareTag("Door2"))
            //{

            //}
        }
    }

    //private void ToggleLight()
    //{
    //    if (lightOn)
    //    {
    //        lightSwitch.Play(switchOff.name); // Play switch-off animation
    //        lightOn = false;
    //        Debug.Log("LightTurnedOff");
    //    }
    //    else
    //    {
    //        lightSwitch.Play(switchOn.name); // Play switch-on animation
    //        lightOn = true;
    //        Debug.Log("LightTurnedOn");
    //    }
    //}

    //public void PlayVideo()
    //{
    //    if(videoPlayer != null)
    //    {
    //        rawImage.gameObject.SetActive(true);  // Show the RawImage
    //        videoPlayer.Play();  // Start playing the video
    //        Debug.Log("Video 1 is playing"); 
    //    }
        
    //}

    //public void PlayVideo2()
    //{
    //    if(videoPlayer2 != null)
    //    {
    //        rawImage2.gameObject.SetActive(true);
    //        videoPlayer2.Play();
    //        Debug.Log("Video 2 is playing"); 
    //    }
       
    //}

    public void TurnOffSiren()
    {
        emergencySiren.SetActive(false);

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

    private IEnumerator BringUpControlPanel()
    {
        yield return new WaitForSeconds(2.3f);
        ConsoleAnimation.SetBool("FinalBoss", false);
        ConsoleAnimation.enabled = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Welcome"))
        {
            CheckWelcomeTriggerandDisplayMessage();
        }

        else if (other.gameObject.CompareTag("SwitchOff"))
        {
            CheckSwitchOffTag();
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            welcomeText.SetActive(false);
            Destroy(objectTrigger); 
        }

       else if (other.CompareTag("SwitchOff"))
        {
            Destroy(switchOff);
        }
    }

    private void CheckDoor2TagAndDisplayMessage()
    {
        // Example: Check the tag of the objectToCheck and display different messages
        if (objectToCheck.CompareTag("Door2"))
        {
            messageText.text = "SWITCH OFF THE EMERGENCY SIREN AT SWITCH";
            switchOffTheEmergencySiren.SetActive(true);
        }
    }

    private void CheckSwitchTagAndDisplayMessage()
    {
        if (objectToCheckSwitch.CompareTag("Switch"))
        {
            messageText.text = "EXPLORE THE OFFICE FOR INFORMATION AND SUPPLIES";
            exploreTheOfficeAudio.SetActive(true);
        }
    }

    private void CheckGunAndDisplayMessage()
    {
        if (objectCheckGun.CompareTag("Gun"))
        {
            messageText.text = "LOOK AROUND FOR LENA AND THE ROBOT'S PICTURE";
            lookAroundForLenaPicAudio.SetActive(true);
        }
    }

     public void CheckKeycardAndDisplayMessage()
    {

        if (objectToCheck.CompareTag("KeyCard"))
        {
            messageText.text = "PROCEED TO UNLOCK THE OFFICE DOOR WITH THE KEYCARD";
            proceedToUnlockAudio.SetActive(true);
        }
    }

    public void CheckWrenchAndDisplayMessage()
    {
        if (objectCheckWrench.CompareTag("PickUp"))
        {
            messageText.text = "DROP THE WRENCH ON THE ROBOT TO MOVE IT OUT OF THE WAY!";
            dropWrenchAudio.SetActive(true);
        }
    }


    public void CheckWelcomeTriggerandDisplayMessage()
    {
        if (objectTrigger.CompareTag("Welcome"))
        {
            messageText.text = "WELCOME MX37! POWER ON!";
            welcomeAudio.SetActive(true);
        }
    }

    public void CheckPhotoAndDisplayMessage()
    {
        if (lenaPhoto.CompareTag("Lena'sPhoto"))
        {
            messageText.text ="TAKE THIS PHOTO AND HEAD TO LENA'S OFFICE FOR THE FINAL DECISION";
            finalDecisionAudio.SetActive(true);
        }
    }


    public void CheckSwitchOffTag()
    {
        if (switchOff.CompareTag("SwitchOff"))
        {
            messageText.text = "SWITCH OFF THE EMERGENCY SIREN AT SWITCH";
            switchOffSirenAudio.SetActive(true);
        }
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

