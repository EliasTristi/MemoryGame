using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoFoundState : BoardStateBaseClass
    {
        public BoardTwoFoundState(MemoryBoard board) : base(board)
        {
            State = BoardStates.TwoFound;
        }

        public override void AddPreview(Tile tile)
        {
            //remain empty
        }

        public override void TileAnimationEnded(Tile tile)
        {
            tile.Board.PreviewingTiles.Remove(tile);

            //Debug.Log(tile.Board.PreviewingTiles.Count);

            if (tile.Board.PreviewingTiles.Count == 0)
            {
                if (Board.Tiles.Where(t => t.State.State == TileStates.Hidden).Count() < 2)
                {
                    tile.Board.PlayerOne.IsActivePlayer = false;
                    tile.Board.PlayerTwo.IsActivePlayer = false;
                    tile.Board.BoardState = new BoardFinishedState(tile.Board);
                }
                else
                {
                    tile.Board.BoardState = new BoardNoPreviewState(tile.Board);
                }
            }
        }
    }
}