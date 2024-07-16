using System;
using UnityEngine;

namespace Game6_KatamariDamacy.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject ballGO;
        [SerializeField] private Vector3 lookAtOffset;
        private void Start()
        {
            
        }

        private void Update()
        {
            transform.LookAt(ballGO.transform.position + lookAtOffset);
        }
    }
}
