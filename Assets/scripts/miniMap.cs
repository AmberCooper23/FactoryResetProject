using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    public RectTransform minimapPoint_1;
    public RectTransform minimapPoint_2;
    public Transform worldpoint_1;
    public Transform worldpoint_2;

    public RectTransform playerMiniMap;
    public Transform playerWorld;

    private float minimapRatio;

    private void Awake()
    {
        CalculateMapRatio();
    }

    private void Update()
    {
        playerMiniMap.anchoredPosition = minimapPoint_1.anchoredPosition + new Vector2((playerWorld.position.x - worldpoint_1.position.x) * minimapRatio, (playerWorld.position.z - worldpoint_1.position.z) * minimapRatio);

    }

    public void CalculateMapRatio()
    {
        Vector3 distanceWorldVector = worldpoint_1.position - worldpoint_2.position;
        distanceWorldVector.y = 0f;
        float distanceWorld = distanceWorldVector.magnitude;

        float distanceMap = Mathf.Sqrt(Mathf.Pow((minimapPoint_1.anchoredPosition.x - minimapPoint_2.anchoredPosition.x), 2)) + Mathf.Pow((minimapPoint_1.anchoredPosition.y - minimapPoint_2.anchoredPosition.y), 2);
   
        minimapRatio = distanceMap / distanceWorld;
    }
}
