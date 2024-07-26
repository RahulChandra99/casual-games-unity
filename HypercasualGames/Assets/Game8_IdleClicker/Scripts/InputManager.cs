using System;
using UnityEngine;

namespace Game8_IdleClicker.Scripts
{
    public class InputManager : MonoBehaviour
    {
        [Header("Actions")]
        public static Action onObjectClicked;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                ThrowRaycast();
        }

        void ThrowRaycast()
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

            if (hit.collider == null)
                return;
            
            onObjectClicked?.Invoke();
        }
    }
}
