using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game7_Minesweeper.Scripts
{
    public class Board : MonoBehaviour
    {
        // Public properties for various tile types
        public Tilemap tilemap { get; private set; }

        // Tiles for different game states
        public Tile tileUnknown,
                    tileEmpty,
                    tileMine,
                    tileExploded,
                    tileFlag,
                    tileNum1,
                    tileNum2,
                    tileNum3,
                    tileNum4,
                    tileNum5,
                    tileNum6,
                    tileNum7,
                    tileNum8;
        
        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }

        // Draws the game board based on the state of each cell
        public void Draw(Cell[,] state)
        {
            int width = state.GetLength(0);  // Get the width of the board
            int height = state.GetLength(1); // Get the height of the board

            // Iterate through each cell in the state array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = state[x, y];  // Get the current cell
                    // Set the tile on the tilemap based on the cell's state
                    tilemap.SetTile(cell.position, GetTile(cell));
                }
            }
        }

        // Returns the appropriate tile for the given cell based on its state
        Tile GetTile(Cell cell)
        {
            if (cell.revealed)
            {
                // If the cell is revealed, get the appropriate revealed tile
                return GetRevealed(cell);
            }
            else if (cell.flagged)
            {
                // If the cell is flagged, return the flag tile
                return tileFlag;
            }
            else
            {
                // If the cell is not revealed or flagged, return the unknown tile
                return tileUnknown;
            }
        }

        // Returns the appropriate tile for a revealed cell based on its type
        private Tile GetRevealed(Cell cell)
        {
            switch (cell.typeCell)
            {
                case Cell.TypeOfCell.Empty:
                    // Return empty tile for empty cells
                    return tileEmpty;
                case Cell.TypeOfCell.Mine:
                    // Return mine tile for mine cells
                    return tileMine;
                case Cell.TypeOfCell.Number:
                    // Return number tile for number cells
                    return GetNumberTile(cell);
                default:
                    // Return null if the cell type is unknown
                    return null;
            }
        }

        // Returns the appropriate number tile based on the cell's number
        private Tile GetNumberTile(Cell cell)
        {
            switch (cell.number)
            {
                case 1: return tileNum1;
                case 2: return tileNum2;
                case 3: return tileNum3;
                case 4: return tileNum4;
                case 5: return tileNum5;
                case 6: return tileNum6;
                case 7: return tileNum7;
                case 8: return tileNum8;
                default: return null;
            }
        }
    }
}
