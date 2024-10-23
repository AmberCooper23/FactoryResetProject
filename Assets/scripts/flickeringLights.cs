using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringLights : MonoBehaviour
{
    public float minIntensity = 25f;
    public float maxIntensity = 50f;
    public float flickerDelay = 0.1f;
    public Light lights;

    private void Start()
    {
        StartCoroutine(Flicker());
    }
    IEnumerator Flicker()
    {
        while (true)
        {
            lights.intensity = Random.Range(minIntensity, maxIntensity);

            yield return new WaitForSeconds(flickerDelay);
        }
    }
}
