using Memory.Models.States;
using Memory.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private IBoardState _boardState;
        private Player _playerOne;
        private Player _playerTwo;

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
        public IBoardState BoardState
        {
            get => _boardState;
            set
            {
                if (_boardState == value) return;
                _boardState = value;
                OnPropertyChanged();
            }
        }

        //CHECK: this is a WIP
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
            int j = 0;

            var shuffledTiles = ExtensionMethods.Shuffle(Tiles);
            
            for (int i = 0; i < shuffledTiles.Count; i++)
            {
                shuffledTiles[i].MemoryCardID = j;
                
                if (i % 2 != 0) //odd
                {
                    j++;
                }
            }
        }

        public override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName.Equals(nameof(BoardState)))
            {
                Debug.Log(BoardState.State);
            }
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}