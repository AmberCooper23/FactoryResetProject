using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;
    public float minBlinkTime, maxBlinkTime;
    bool isLooping = true;

    private void Start()
    {
        StartCoroutine(eyesOpening()); 
    }

    public IEnumerator eyesOpening()
    {
        while(isLooping == true)
        {
            yield return new WaitForSeconds(Random.Range(minBlinkTime, maxBlinkTime)); //chooses a random number of seconds between min and max blink time
            anim.SetTrigger("Blinky");
        }
        yield return new WaitForSeconds(Random.Range(minBlinkTime, maxBlinkTime)); //chooses a random number of seconds between min and max blink time
        anim.SetTrigger("Blinky");
    }
}
