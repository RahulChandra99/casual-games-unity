using System;
using UnityEngine;

namespace Game7_Minesweeper.Scripts
{
    public class GameLogic : MonoBehaviour
    {
        public int width = 16;
        public int height = 16;
        public int mineCount = 32;

        private Board board;
        private Cell[,] state;

        private void Awake()
        {
            board = GetComponentInChildren<Board>();
        }

        private void Start()
        {
            NewGame();
        }

        private void NewGame()
        {
            state = new Cell[width, height];
            
            GenerateCells();
            GenerateMines();
            GenerateNumbers();

            if (Camera.main != null)
                Camera.main.transform.position = new Vector3(width / 2f, height / 2f, Camera.main.transform.position.z);

            board.Draw(state);
            
        }

        private void GenerateCells()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = new Cell();
                    cell.position = new Vector3Int(x, y, 0);
                    cell.typeCell = Cell.TypeOfCell.Empty;
                    state[x, y] = cell;
                }
            }
            
            
        }

        private void GenerateMines()
        {
            for (int i = 0; i < mineCount; i++)
            {
                int x = UnityEngine.Random.Range(0, width);
                int y = UnityEngine.Random.Range(0, height);

                while (state[x, y].typeCell == Cell.TypeOfCell.Mine)
                {
                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y++;
                        if (y >= height)
                        {
                            y = 0;
                        }
                    }
                    
                }
                
                state[x, y].typeCell = Cell.TypeOfCell.Mine;
                state[x, y].revealed = true;
            }
        }

        private void GenerateNumbers()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cell cell = state[x, y];
                    
                    if(cell.typeCell == Cell.TypeOfCell.Mine)
                        continue;

                    cell.number = CountMines(x, y);
                }
            }
        }

        private int CountMines(int cellX, int cellY)
        {
            int count = 0;

            for (int adjacentX = -1; adjacentX <= 1; adjacentX++)
            {
                for (int adjacentY = -1; adjacentY <= 1; adjacentY++)
                {
                    if(adjacentX == 0 && adjacentY == 0)
                        continue;
                    
                    int x = cellX + adjacentX;
                    int y = cellY + adjacentY;

                    if (state[x, y].typeCell == Cell.TypeOfCell.Mine)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
    }
}
