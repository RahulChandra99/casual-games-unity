using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    int numRows = 6;
    int numColumns = 7;

    int[,] playfield = new int[6,7] 
    {
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
    };

    private void Start()
    {
        DropCoin(3, 1);
        DropCoin(6, 1);
    }

    //playerNumber = 0(none), 1 = player, 2 = 2p
    bool DropCoin(int columnToFill, int playerNumber)
    {
        for(int i = numRows-1; i >= 0; i--)
        {
            if (playfield[i, columnToFill] == 0)
            {
                playfield[i, columnToFill] = playerNumber;
                Debug.Log(DebugBoard());
                return true;
            }
        }
        return false;
    }

    string DebugBoard()
    {
        string s = "";
        string seperator = ",";
        string border = "|";

        for( int x = 0; x<numRows; x++ )
        {
            s += border;
            for(int y = 0;y<numColumns; y++ )
            {
                s += playfield[x, y];
                s += seperator;
            }
            s+= border + "\n";
        }

        return s;
    }
}
