using UnityEngine;

namespace Game7_Minesweeper.Scripts
{
    public class Cell : MonoBehaviour
    {
        public enum TypeOfCell
        {
            Empty,
            Mine,
            Number
        }

        public Vector3Int position;
        public TypeOfCell typeCell;
        public int number;
        public bool revealed;
        public bool flagged;
        public bool exploded;
    }
}
