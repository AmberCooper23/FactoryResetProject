using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap1 : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
