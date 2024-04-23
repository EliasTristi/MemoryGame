using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        private MemoryBoard _board;

        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {
            State = BoardStates.NoPreview;
            _board = board;
        }

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden) return;

            tile.State = new TilePreviewingState(tile);

            //CHECK: if correct usage of _board
            _board.PreviewingTiles.Add(tile);

            _board.BoardState = new BoardOnePreviewState(_board);
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //remain empty
        }
    }
}