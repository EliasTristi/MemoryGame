//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class MemoryBoard : ModelBaseClass
    {
        //variables
        private int _rows;
        private int _columns;
        private List<Tile> _tiles = new List<Tile>();
        private List<Tile> _previewingTiles = new List<Tile>();
        private bool _isCombinationFound;

        //properties
        public int Rows
        {
            get => _rows;
            set
            {
                if (_rows == value) return;
                _rows = value;
                OnPropertyChanged();
            }
        }
        public int Columns
        {
            get => _columns;
            set
            {
                if (_columns == value) return;
                _columns = value;
                OnPropertyChanged();
            }
        }
        public List<Tile> Tiles
        {
            get => _tiles;
            set
            {
                if (_tiles == value) return;
                _tiles = value;
                OnPropertyChanged();
            }
        }
        public List<Tile> PreviewingTiles
        {
            get => _previewingTiles;
            set
            {
                if (_previewingTiles == value) return;
                _previewingTiles = value;
                OnPropertyChanged();
            }
        }
        public bool IsCombinationFound
        {
            get => _isCombinationFound;
            set
            {
                if (_isCombinationFound == value) return;
                _isCombinationFound = value;
                OnPropertyChanged();
            }
        }

        //constructor
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
            //biggest ID would be the count of the Tiles list / 2

            //array with the different ID's for pairs

            //random.range() to grab one of the ID for a pair

            //grab a random tile and assign the random ID
            ////when done, immediatly grab another random tile and assign same ID
            ////after which remove the ID from the array

            int i = 0;

            foreach (var tile in Tiles)
            {
                tile.MemoryCardID = i;
                i++;
            }




            //int pairCount = Tiles.Count / 2;

            //// List to keep track of assigned IDs
            //List<int> assignedIds = new List<int>();

            //for (int id = 0; id < pairCount; id++)
            //{
            //    // Each ID should be assigned to two tiles
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Tile tile;
            //        do
            //        {
            //            // Randomly select a tile
            //            tile = Tiles[Random.Range(0, Tiles.Count)];
            //        }
            //        // Ensure this tile has not already been assigned an ID
            //        while (assignedIds.Contains(tile.MemoryCardID));

            //        // Assign the ID to the tile
            //        // Assuming your Tile class has a method to set its ID
            //        tile.MemoryCardID = id;

            //        // Mark this tile as having been assigned an ID
            //        assignedIds.Add(tile.MemoryCardID);
            //    }
            //}

            //// If there is an odd number of tiles, assign the last unique ID to the remaining tile
            //if (Tiles.Count % 2 != 0)
            //{
            //    for (int i = 0; i < Tiles.Count; i++)
            //    {
            //        if (!assignedIds.Contains(Tiles[i].MemoryCardID))
            //        {
            //            Tiles[i].MemoryCardID = pairCount;
            //            break; // Exit the loop once the last ID is assigned
            //        }
            //    }
            //}
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}