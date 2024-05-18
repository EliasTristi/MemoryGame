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
            if (tile.Board.PreviewingTiles.Count == 2 && tile == tile.Board.PreviewingTiles[1])
            {
                tile.Board.BoardState = new BoardTwoHidingState(tile.Board);

                foreach (var previewTile in tile.Board.PreviewingTiles)
                {
                    previewTile.State = new TileHiddenState(previewTile);
                }
            }
        }
    }
}