using Memory.Models.States;
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
        public IBoardState BoardState { get; set; }

        //CHECK: this needs to be adjusted
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        //constructor
        public MemoryBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    var tile = new Tile(row, column, this);
                    tile.State = new TileHiddenState(tile);
                    Tiles.Add(tile);
                }
            }

            AssignMemoryCardIds();

            BoardState = new BoardNoPreviewState(this);
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
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}