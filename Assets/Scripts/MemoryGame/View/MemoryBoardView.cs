using Memory.Models;
using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.View
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        //variables
        private MemoryBoard _board;
        private PlayerView _playerViewOne;
        private PlayerView _playerViewTwo;

        //properties
        public PlayerView PlayerViewOne
        {
            get => _playerViewOne;
            set
            {
                _playerViewOne = value;
                _playerViewOne.Model = new Player("Ben", 0, true);
            }
        }
        public PlayerView PlayerViewTwo
        {
            get => _playerViewTwo;
            set
            {
                _playerViewTwo = value;
                _playerViewTwo.Model = new Player("Ann", 0, false);
            }
        }

        public MemoryBoardView()
        {
            //default
        }

        public void SetUpMemoryBoard(MemoryBoard board, GameObject tilePrefab, Material[] materials)
        {
            _board = board;

            _board.PlayerOne = _playerViewOne.Model;
            _board.PlayerTwo = _playerViewTwo.Model;

            var tiles = board.Tiles;

            foreach (var tile in tiles)
            {
                var offset = new Vector3(-1f, 0, -1f);
                var posX = transform.position.x + tile.Row + offset.x;
                var posZ = transform.position.z + tile.Column + offset.z;
                var position = new Vector3(posX, 0f, posZ);

                var newTile = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, this.transform);

                var tileFace = newTile.GetComponent<TileView>().TileTopFace;
                tileFace.GetComponent<Renderer>().sharedMaterial = materials[tile.MemoryCardID];

                newTile.GetComponent<TileView>().Model = tile;
            }
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: implement Model_PropertyChanged logic
        }
    }
}