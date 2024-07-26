using System;
using UnityEngine;

namespace Game8_IdleClicker.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        [Header("Data")] 
        public double incrementValue = 0;
        public double objectClickerCounter = 0;
        
        private void Awake()
        {
            LoadData();
            
            InputManager.onObjectClicked += ObjectClickedCallback;
        }

        private void OnDestroy()
        {
            InputManager.onObjectClicked -= ObjectClickedCallback;
            
            SaveData();
        }

        void ObjectClickedCallback()
        {
            objectClickerCounter += incrementValue;
        }

        void SaveData()
        {
            PlayerPrefs.SetString("Objects",objectClickerCounter.ToString());
        }

        void LoadData()
        {
            double.TryParse(PlayerPrefs.GetString("Objects"), out objectClickerCounter);
        }
    }
}
