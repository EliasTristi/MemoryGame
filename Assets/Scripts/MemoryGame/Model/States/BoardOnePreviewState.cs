using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardOnePreviewState : BoardStateBaseClass
    {
        public BoardOnePreviewState(MemoryBoard board) : base(board)
        {
            State = BoardStates.OnePreview;
        }

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State != TileStates.Hidden) return;

            tile.Board.PreviewingTiles.Add(tile);

            if (tile.Board.PreviewingTiles.Count == 2)
            {
                if (tile.Board.IsCombinationFound)
                {
                    tile.Board.BoardState = new BoardTwoFoundState(tile.Board);

                    foreach (var prevTile in tile.Board.PreviewingTiles)
                    {
                        prevTile.State = new TilePreviewingState(prevTile);
                    }
                }
                else
                {
                    tile.Board.BoardState = new BoardTwoPreviewState(tile.Board);

                    tile.State = new TilePreviewingState(tile);
                }
            }
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //remain empty
        }
    }
}