using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [HideInInspector] public bool isActive = true;

    public Line line;
    public Park park;
    public Car car;

    public Color carColor;
 
    public void DisActive()
    {
        isActive = false;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying && line != null && car != null && park != null)
        {
            line.lineRenderer.SetPosition(0,car.bottomTransform.position);
            line.lineRenderer.SetPosition(1,park.transform.position);
            
            car.SetColor(carColor);
            park.SetColor(carColor);
            line.SetColor(carColor);
        }
    }
}
