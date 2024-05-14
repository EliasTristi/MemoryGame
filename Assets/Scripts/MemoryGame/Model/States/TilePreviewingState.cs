using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TilePreviewingState : TileStateBaseClass
    {
        public TilePreviewingState(Tile tile) : base(tile)
        {
            State = TileStates.Preview;
        }
    }
}