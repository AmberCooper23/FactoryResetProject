using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionForCityDestroy : MonoBehaviour
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
            if (hit.collider.gameObject.GetComponent<City>())
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
