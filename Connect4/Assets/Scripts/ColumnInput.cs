using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInput : MonoBehaviour
{
    public int column;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.ColumnPressed(column);
        }
    }
}