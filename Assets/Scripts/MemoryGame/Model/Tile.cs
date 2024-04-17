using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Tile : ModelBaseClass
    {
        //variables
        private int _memoryCardID;
        
        //properties
        public int Row { get; }
        public int Column { get; }
        public MemoryBoard Board { get; }
        public int MemoryCardID
        {
            get => _memoryCardID;
            set
            {
                if (_memoryCardID == value) return;
                _memoryCardID = value;
                OnPropertyChanged();
            }
        }

        public Tile(int row, int column, MemoryBoard board)
        {
            Row = row;
            Column = column;
            Board = board;
        }

        public override string ToString()
        {
            return $"Tile({Row},{Column})";
        }
    }
}