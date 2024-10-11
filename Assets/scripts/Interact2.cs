using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact2 : MonoBehaviour
{
    public float interactionDistance;
    public GameObject interactionText;
    public LayerMask interactionLayers;

    public bool isHoldingObject;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
        {
            if (hit.collider.gameObject.GetComponent<PickUpInteraction>())
            {
                interactionText.SetActive(true);
                
            }
            else
            {
                interactionText.SetActive(false);
            }
        }
        

    }

    public void DropObject()
    {
        isHoldingObject = false; 
    }
}
