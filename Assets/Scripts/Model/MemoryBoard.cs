using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBoard: ModelBaseClass
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public List<Tile> Tiles { get; set; }
    public List<Tile> PreviewingTiles { get; set; }
    public bool IsCombinationFound { get; }

    public MemoryBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                Tiles.Add(new Tile(row, column, this));
            }
        }

        AssignMemoryCardIds();
    }

    private void AssignMemoryCardIds()
    {
        //biggest ID would be the  
    }

    public override string ToString()
    {
        return $"MemoryBoard({Rows},{Columns})";
    }
}
