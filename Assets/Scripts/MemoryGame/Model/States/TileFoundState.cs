using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TileFoundState : TileStateBaseClass
    {
        public TileFoundState(Tile tile) : base(tile)
        {
            State = TileStates.Found;
        }
    }
}