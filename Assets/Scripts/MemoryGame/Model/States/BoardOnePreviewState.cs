using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            //checking if tile state is hidden and adding it to preview list
            if (tile.State.State != TileStates.Hidden) return;
            tile.Board.PreviewingTiles.Add(tile);

            //checking if all tiles have the same ID
            var firstTile = tile.Board.PreviewingTiles[0];
            var combinationFound = tile.Board.PreviewingTiles.All(t => t.MemoryCardID == firstTile.MemoryCardID);
            
            if (combinationFound && tile.Board.PreviewingTiles.Count == 2)
                tile.Board.IsCombinationFound = true;


            //update state of board and tile
            if (tile.Board.IsCombinationFound)
            {
                tile.Board.BoardState = new BoardTwoFoundState(tile.Board);
                tile.State = new TileFoundState(tile);
                tile.Board.IsCombinationFound = false;
            }
            else
            {
                tile.Board.BoardState = new BoardTwoPreviewState(tile.Board);
                tile.State = new TilePreviewingState(tile);
                
            }
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //remain empty
        }
    }
}