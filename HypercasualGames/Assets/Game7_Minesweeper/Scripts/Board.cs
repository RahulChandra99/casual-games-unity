using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game7_Minesweeper.Scripts
{
    public class Board : MonoBehaviour
    {
        public Tilemap tilemap { get; private set; }

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

        public void Draw(Cell[,] state)
        {
            int width = state.GetLength(0);
            int height = state.GetLength(1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = state[x, y];
                    tilemap.SetTile(cell.position, GetTile(cell));
                }
            }
            
        }

        Tile GetTile(Cell cell)
        {
            if (cell.revealed)
            {
                return GetRevealed(cell);

            }
            else if (cell.flagged)
            {
                return tileFlag;
            }
            else
            {
                return tileUnknown;
            }

        }

        private Tile GetRevealed(Cell cell)
        {
            switch (cell.typeCell)
            {
                case Cell.TypeOfCell.Empty :
                    return tileEmpty;
                case Cell.TypeOfCell.Mine :
                    return tileMine;
                case Cell.TypeOfCell.Number :
                    return GetNumberTile(cell);
                default:
                    return null;
            }
        }

        private Tile GetNumberTile(Cell cell)
        {
            switch (cell.number)
            {
                case 1: return tileNum1;
                case 2: return tileNum2;
                case 3: return tileNum3;
                case 4: return tileNum3;
                case 5: return tileNum5;
                case 6: return tileNum6;
                case 7: return tileNum7;
                case 8: return tileNum8;
                default: return null;
            }
        }
    }
}
