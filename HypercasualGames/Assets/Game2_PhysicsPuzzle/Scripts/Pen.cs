using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{

    [SerializeField] private GameObject _dot;

    private void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(_dot, objectPosition, Quaternion.identity);
        }
    }
}
