using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDzoouh2 : MonoBehaviour
{
    private bool OpenDoor2;

    private void Update()
    {
        if (OpenDoor2)
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
