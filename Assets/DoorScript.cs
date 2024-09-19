using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float interactDistance;
    public GameObject intText;
    public string doorOpenAnim, doorCloseAnim;


    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject.tag == "Door2")
            {
                GameObject DoorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim = DoorParent.GetComponent<Animator>();
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.O))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnim))
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }

                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnim))
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                }

            }
            else
            {
                intText.SetActive(false);
            }

        }

    }
}
