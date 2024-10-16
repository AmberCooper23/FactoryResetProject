using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpen : MonoBehaviour
{
    public Transform Hinge;
    public float openAngle;
    private bool open;

    private void OnTriggerEnter(Collider other)
    {
        OpenSafe();
    }
    public void OnTriggerExit(Collider other)
    {
        CloseSafe();
    }

    public void OpenSafe()
    {
        Debug.Log("Opening");
        Hinge.Rotate(0, openAngle, 0);
    }

    public void CloseSafe()
    {
        Debug.Log("closing");
        Hinge.Rotate(0, -openAngle, 0);
    }
}
