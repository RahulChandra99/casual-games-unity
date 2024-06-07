using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;// The purpose of this is to ensure that there is only one instance of the GameManager class throughout the game's runtime

    [SerializeField] private GameObject _player;

    private void Awake()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        if(_player.transform.position.y <= Camera.main.transform.position.y)
        {
            Vector3 oldCamPos = Camera.main.transform.position;
            Vector3 newCamPos = new Vector3(0, oldCamPos.y - 1f, oldCamPos.z);
            Camera.main.transform.position = Vector3.Lerp(oldCamPos,newCamPos,2f * Time.deltaTime);
        }
    }
}
