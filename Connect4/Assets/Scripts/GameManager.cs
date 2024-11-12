using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int _currentPlayer = 1;

    public GameObject player1;
    public GameObject player2;

    private bool _activeTurn = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void ColumnPressed(int column)
    {
        
    }
}
