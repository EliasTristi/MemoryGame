using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {
            State = BoardStates.NoPreview;
        }

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden) return;

            tile.State = new TilePreviewingState(tile);

            //CHECK: if correct usage of _board
            tile.Board.PreviewingTiles.Add(tile);

            tile.Board.BoardState = new BoardOnePreviewState(tile.Board);
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //remain empty
        }
    }
}