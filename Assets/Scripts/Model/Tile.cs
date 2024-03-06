using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ModelBaseClass
{
    public int Row { get; }
    public int Column { get; }
    public MemoryBoard Board { get; }

    private int _memoryCardID;
    public int MemoryCardID
    {
        get => _memoryCardID;
        set
        {
            _memoryCardID = value;
            OnPropertyChanged(nameof(MemoryCardID));
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
