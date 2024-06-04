using Memory.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardResettingState : BoardStateBaseClass
    {
        public BoardResettingState(MemoryBoard board) : base(board)
        {
            State = BoardStates.Resetting;
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden) return;

            var repo = ImageRepository.Instance;

            if (tile.Board.ResetTiles.Count <= 1)
            {
                tile.Board.ResetTiles.Remove(tile);
                tile.Board.PreviewingTiles.Clear();
                
                if (tile.Board.PlayerOne.IsActivePlayer)
                {
                    //repository post the active player in the DB
                    repo.AddReset(tile.Board.PlayerOne.Name);
                }
                else
                {
                    //same as above
                    repo.AddReset(tile.Board.PlayerTwo.Name);
                }

                ResetPlayers(tile);

                tile.Board.BoardState = new BoardNoPreviewState(tile.Board);
                Debug.Log($"New Tile count: {tile.Board.ResetTiles.Count}");
            }
            else
            {
                tile.Board.ResetTiles.Remove(tile);
            }
        }

        private void ResetPlayers(Tile tile)
        {
            var playerOne = tile.Board.PlayerOne;
            var playerTwo = tile.Board.PlayerTwo;

            //reset elapsed time
            playerOne.Elapsed = 0f;
            playerTwo.Elapsed = 0f;

            //reset score
            playerOne.Score = 0;
            playerTwo.Score = 0;

            //reset active player
            playerTwo.IsActivePlayer = false;
            playerOne.IsActivePlayer = true;
        }
    }
}