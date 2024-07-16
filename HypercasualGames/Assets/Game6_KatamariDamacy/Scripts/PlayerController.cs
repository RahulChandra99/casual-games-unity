using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game6_KatamariDamacy.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float facingAngle;
        private float x, z;
        private Vector2 unitVector2;

        [SerializeField] private GameObject mainCamera;
        private float distanceToCamera = 5;

        private void Update()
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
            z = Input.GetAxis("Vertical") * Time.deltaTime * 500;

            facingAngle += x;
            unitVector2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));
        }

        private void FixedUpdate()
        {
            this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitVector2.x, 0, unitVector2.y) * (z * 3));

            mainCamera.transform.position =
                new Vector3(-unitVector2.x * distanceToCamera, distanceToCamera, -unitVector2.y * distanceToCamera) +
                this.transform.position;
        }
    }
}
