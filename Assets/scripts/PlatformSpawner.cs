using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject PlatformGameObject;
    public bool isPlatformActive = false;
    public GameObject Bullet;


    public void Awake()
    {
        PlatformGameObject.SetActive(false);
        Debug.Log("Platform dissapears");
    }

    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == Bullet)
        {
            PlatformGameObject.SetActive(true);
            Debug.Log("Platform appears");
        }

        //if (other.gameObject.CompareTag("Bullet"))
        //{
            //Debug.Log("compare tag");

            //// Activate gravity on the boulder
            //if (other.gameObject.tag == "PlatformTrigger" )
            //{
            //    isPlatformActive = true;
            //    Debug.Log("Trigger activated");
            //    gameObject.SetActive(true);

            //}

            //else
            //{
            //    isPlatformActive = false;
            //    gameObject.SetActive(false);
            //    Debug.Log("Trigger not activated");
            //}

        }

    }

