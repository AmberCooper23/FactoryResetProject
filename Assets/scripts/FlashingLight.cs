using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public float delay= 1f ;
    public float minIntensity = 6f;
    public float maxIntensity = 1f;
    public bool startAtMin;

    private Light myLight;

    private float timeElapsed;

    private void Awake()
    {
        myLight = GetComponent<Light>();

        if( myLight != null )
        {
            myLight.intensity = startAtMin ? minIntensity : maxIntensity;
        }
    }

    private void Update()
    {
        if (myLight != null)
        {
            timeElapsed += Time.deltaTime;
           
            if (timeElapsed >= delay)
            {
                timeElapsed = 0;

                ToggleLight();
            }
        }
    }

    public void ToggleLight()
    {
        if (myLight !=null)
        {
            if(myLight.intensity == minIntensity)
            {
                myLight.intensity = maxIntensity; // when it reaches the max, then it switches to min
            }
            else if(myLight.intensity == maxIntensity)
            {
                myLight.intensity = minIntensity; // when it reaches the min, then it switches to max
            }
        }
    }
}
