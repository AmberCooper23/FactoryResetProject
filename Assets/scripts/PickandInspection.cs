//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class PickUpandInspection : MonoBehaviour
//{
//    public GameObject mainCamera;
//    public GameObject examineCamera;
//    public Light examineLight;
//    public GameObject Hud;
//    public Behaviour Player;

//    public GameObject InteractText;
//    public GameObject ExamineUI;
//    public bool inReach;
//    public bool isExaminable;

//    public Transform target;
//    public float speedY;
//    public float speedX;
//    public float rootY;
//    public float rootX;

//    [Header("Specific Object")]
//    public GameObject examineObject;
//    public GameObject specificObject;
//    public GameObject inventoryObject;
//    public GameObject infoText;
//    public GameObject PlayerObject;


//    private void Start()
//    {
//        examineLight.enabled = false;
//        inventoryObject.SetActive(false);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Reach")
//        {
//            inReach = true;
//            InteractText.SetActive(true);

//        }

//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.tag == "Reach")
//        {
//            inReach = false;
//            InteractText.SetActive(false);
//        }
//    }

//    void Update()
//    {
//        if (inReach && Input.GetButtonDown("Interact"))
//        {
//            mainCamera.SetActive(false);
//            examineCamera.SetActive(true);
//            isExaminable = true;
//            Player.GetComponent<PlayerController>().Disable();
//            InteractText.SetActive(false);
//            ExamineUI.SetActive(true);
//            Hud.SetActive(false);
//            examineObject.SetActive(true);
//            examineLight.enabled = true;
//            infoText.SetActive(true);
//            Time.timeScale = 0;

//        }

//        if (isExaminable == true && Input.GetMouseButtonDown(0))
//        {
//            rootY += PlayerObject.GetComponent<FirstPersonControls>().lookInput.y = speedY;
//            rootX += PlayerObject.GetComponent<FirstPersonControls>().lookInput.x = speedX;
//            rootY = Mathf.Clamp(rootY, -360f, 360f);
//        }

//        target.eulerAngles = new Vector3(rootY, rootX - rootX, 0);

//        if (isExaminable = true && Input.GetButtonDown("Escape"))
//        {
//            mainCamera.SetActive(true);
//            examineCamera.SetActive(false);
//            isExaminable = false;
//            Player.GetComponent<PlayerController>().Enable();
//            InteractText.SetActive(true);
//            ExamineUI.SetActive(false);
//            Hud.SetActive(true);
//            examineObject.SetActive(false);
//            examineLight.enabled = false;
//            infoText.SetActive(false);
//            Time.timeScale = 1;
//        }

//        if (isExaminable == true && Input.GetMouseButtonDown(1))
//        {
//            mainCamera.SetActive(true);
//            examineCamera.SetActive(false);
//            isExaminable = false;
//            Player.GetComponent<PlayerController>().Enable();
//            ExamineUI.SetActive(false);
//            Hud.SetActive(true);
//            examineObject.SetActive(false);
//            specificObject.SetActive(false);
//            inventoryObject.SetActive(true);
//            examineLight.enabled = false;
//            infoText.SetActive(false);
//            Time.timeScale = 1;
//        }
//    }
//}
