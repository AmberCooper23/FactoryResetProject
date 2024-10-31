using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    public Animation lightSwitch;
    public AnimationClip switchOn;   // Animation clip to turn the light on
    public AnimationClip switchOff;  // Animation clip to turn the light off
    public bool lightOn = true;

    public GameObject[] lightsLOL;


    public void ToggleLight()
    {
        if (lightOn)
        {
            lightSwitch.Play(switchOff.name); // Play switch-off animation
            lightOn = false;
            TurnOffLights();
        }
        else
        {
            lightSwitch.Play(switchOn.name); // Play switch-on animation
            lightOn = true;
            TurnOnLights();
        }
    }

    public void TurnOnLights()
    {
        foreach (GameObject lugte in lightsLOL)
        {
            if (lugte != null)
            {
                lugte.SetActive(true);
            }
        }
    }
    public void TurnOffLights()
    {
        foreach (GameObject lugte in lightsLOL)
        {
            if (lugte != null)
            {
                lugte.SetActive(false);
            }
        }
    }

    //private void Update()
    //{
    //    if(lightOn == true)
    //    {
    //        lightsLOL.SetActive(false);
    //    }
    //}
}
