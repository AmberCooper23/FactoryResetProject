//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

//public class waypoint : MonoBehaviour
//{
//    public Image img;
//    public float borderPadding = 20f;

//    public Transform lockerRoomKey;
//    public Transform lockerRoomDoor;
//    public Transform wrench;
//    public Transform keyCard;
//    public Transform officeDoor;
//    public Transform lenaPic;
//    public Transform safe;
//    public Transform activationCertificate;
//    public Transform gun;
//    public Transform mainDoor;
//    public Transform gunBlueprints;
//    public Transform pictureOfLena;
//    public Transform console;

//    private Camera mainCamera;
//    void Start()
//    {
//        mainCamera = Camera.main;

//        if ( lockerRoomKey == null || lockerRoomDoor == null || wrench == null || keyCard == null || officeDoor == null || lenaPic == null || safe == null || activationCertificate == null || gun == null || mainDoor == null || gunBlueprints == null || pictureOfLena == null || console == null )
//        {
//            Debug.LogError("not assigned target");
//        }
//        if(img == null)
//        {
//            Debug.LogError("not assigned img");
//        }
//    }

//    void FrontDesk()
//    {
//        if (lockerRoomKey == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(lockerRoomKey.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }
//    void lockerRoomOpen()
//    {
//        if (lockerRoomDoor == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(lockerRoomDoor.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FixNPC()
//    {
//        if (wrench == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(wrench.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FindKeyCard()
//    {
//        if (keyCard == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(keyCard.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void OfficeDoor()
//    {
//        if (officeDoor == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(officeDoor.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void PicOnDesk()
//    {
//        if (lenaPic == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(lenaPic.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void OpenSafe()
//    {
//        if (safe == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(safe.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FindActivationCertificate()
//    {
//        if (activationCertificate == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(activationCertificate.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FindGun()
//    {
//        if (gun == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(gun.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void GoToPlatforms()
//    {
//        if (mainDoor == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(mainDoor.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void LookAtBlueprints()
//    {
//        if (gunBlueprints == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(gunBlueprints.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FindConsoleKey()
//    {
//        if (pictureOfLena == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(pictureOfLena.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }

//    void FindConsole()
//    {
//        if (console == null || img == null) return;

//        Vector3 screenPosition = mainCamera.WorldToScreenPoint(console.position);

//        if (screenPosition.z < 0)
//        {
//            screenPosition *= -1;
//        }

//        screenPosition.x = Mathf.Clamp(screenPosition.x, borderPadding, Screen.width - borderPadding);
//        screenPosition.y = Mathf.Clamp(screenPosition.y, borderPadding, Screen.height - borderPadding);

//        img.transform.position = screenPosition;
//    }    
//}
