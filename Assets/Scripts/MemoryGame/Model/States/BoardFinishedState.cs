using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardFinishedState : BoardStateBaseClass
    {
        public BoardFinishedState(MemoryBoard board) : base(board)
        {
            State = BoardStates.Finished;
        }

        public override void AddPreview(Tile tile)
        {
            //remain empty
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //remain empty
        }
    }
}