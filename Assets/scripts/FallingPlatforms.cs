using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;


public class FallingPlatforms : MonoBehaviour
{
    private bool isFalling = false;
    public float fallingSpeed = 0f;
    public float maxFallingSpeed = 10f;
    public float acceleration = 0.1f;
    public float destroyDelay = 10f; 
    public float dropDelay = 2f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DropPlatformAfterDelay(dropDelay));
        }

        Destroy(gameObject, destroyDelay);
    }

    private IEnumerator DropPlatformAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isFalling = true;
    }

    private void Update()
    {
        if (isFalling)
        {
            
            fallingSpeed = Mathf.Min(fallingSpeed + acceleration * Time.deltaTime, maxFallingSpeed);
            transform.position += Vector3.down * fallingSpeed * Time.deltaTime; 
        }
    }
}
