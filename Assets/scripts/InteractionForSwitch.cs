using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionForSwitch : MonoBehaviour
{

    [Header("EXAMINE SETTINGS")]
    [Space(5)]
    public float interactionDistance;
    public GameObject interactionText;
    public LayerMask interactionLayers;




    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayers))
        {
            if (hit.collider.gameObject.GetComponent<SwitchOffSiren>())
            {
                interactionText.SetActive(true);
  
            }
            else
            {
                interactionText.SetActive(false);
            }
        }

    }
}
