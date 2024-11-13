using System;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    // Singleton instance to allow global access
    public static PlayField Instance;

    // Constants defining the size of the board
    private const int NumRows = 6;
    private const int NumColumns = 7;

    // 2D array to represent the game board
    // 0 = empty cell, 1 = player 1's coin, 2 = player 2's coin
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
        // Ensure only one instance of PlayField exists (singleton pattern)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Optionally print the initial state of the board (can be enabled for debugging)
        Debug.Log(DebugBoard());
    }

    /// <summary>
    /// Checks for a valid move in the specified column.
    /// </summary>
    /// <param name="column">The column to check for a valid move.</param>
    /// <returns>
    /// The index of the first available row in the column, or -1 if no valid move exists.
    /// </returns>
    public int ValidMove(int column)
    {
        // Iterate from the bottom row to the top
        for (int row = NumRows - 1; row >= 0; row--)
        {
            // Ensure the column index is within bounds
            if (column < NumColumns && column >= 0)
            {
                // Check if the current cell is empty
                if (_board[row, column] == 0)
                {
                    return row;
                }
            }
        }

        // If no valid move exists, log a message and return -1
        Debug.Log("No Valid Space Available");
        return -1;
    }

    /// <summary>
    /// Places a player's coin at the specified position on the board.
    /// </summary>
    /// <param name="x">The row index where the coin is placed.</param>
    /// <param name="y">The column index where the coin is placed.</param>
    /// <param name="player">The player placing the coin (1 or 2).</param>
    public void DropCoin(int x, int y, int player)
    {
        // Update the board to reflect the coin placement
        _board[x, y] = player;

        // Print the updated board for debugging purposes
        //Debug.Log(DebugBoard());

        // (Optional) Add logic here to check for a win condition
        // Example: CheckForWin(x, y, player);
    }

    /// <summary>
    /// Generates a string representation of the board for debugging purposes.
    /// </summary>
    /// <returns>A formatted string representing the current state of the board.</returns>
    private string DebugBoard()
    {
        string boardString = "";
        string separator = ","; // Separator for cells within a row
        string border = "|";    // Border to visually separate rows

        // Iterate through each row
        for (int row = 0; row < NumRows; row++)
        {
            boardString += border; // Add a border at the start of each row
            for (int col = 0; col < NumColumns; col++)
            {
                boardString += _board[row, col]; // Add the cell value
                boardString += separator;       // Add a separator between cells
            }

            boardString += border + "\n"; // Add a border and newline at the end of the row
        }

        return boardString;
    }
}
