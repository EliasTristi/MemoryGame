using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoHidingState : BoardStateBaseClass
    {
        public BoardTwoHidingState(MemoryBoard board) : base(board)
        {
            State = BoardStates.TwoHiding;
        }

        public override void AddPreview(Tile tile)
        {
            //remain empty
        }

        public override void TileAnimationEnded(Tile tile)
        {
            tile.Board.PreviewingTiles.Remove(tile);

            if (tile.Board.PreviewingTiles.Count ==  0)
            {
                tile.Board.ToggleActivePlayer();
                tile.Board.BoardState = new BoardNoPreviewState(tile.Board);
            }
        }
    }
}