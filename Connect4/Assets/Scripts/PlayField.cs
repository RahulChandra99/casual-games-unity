using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public static PlayField Instance;
    
    private const int NumRows = 6;
    private const int NumColumns = 7;
    
    //0 - no coin, 1 = player1, 2 = player2
    private int[,] _board = new int[NumRows, NumColumns]
    {
        { 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0 }
    };

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        print(DebugBoard());
        DropCoin(0, 1);
        DropCoin(0, 1);
        DropCoin(0, 1);
        DropCoin(0, 1);
        DropCoin(0, 1);
        DropCoin(0, 1);
       
    }

    bool DropCoin(int column, int player)
    {
        for (int i = NumRows-1; i >= 0; i--)
        {
            if (column < NumColumns)
            {
                if (_board[i, column] == 0 )
                {
                    _board[i, column] = player;
                    print(DebugBoard());
                    return true;
                }
            }
            
        }
        Debug.Log("No Valid Space Available");
        return false;
    }

    string DebugBoard()
    {
        string s = "";
        string seperator = ",";
        string border = "|";

        for (int x = 0; x < NumRows; x++)
        {
            s += border;
            for (int y = 0; y < NumColumns; y++)
            {
                s += _board[x, y];
                s += seperator;
            }

            s += border + "\n";
        }

        return s;
    }
}
