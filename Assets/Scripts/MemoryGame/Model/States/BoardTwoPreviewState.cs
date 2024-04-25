using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardTwoPreviewState : BoardStateBaseClass
    {
        public BoardTwoPreviewState(MemoryBoard board) : base(board)
        {
            State = BoardStates.TwoPreview;
        }

        public override void AddPreview(Tile tile)
        {
            //remain empty
        }

        public override void TileAnimationEnded(Tile tile)
        {
            tile.Board.BoardState = new BoardTwoHidingState(tile.Board);

            foreach (var prevTile in tile.Board.PreviewingTiles)
            {
                prevTile.State = new TileHiddenState(prevTile);
            }
        }
    }
}