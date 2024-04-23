using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TileStateBaseClass : ITileState
    {
        public TileStates State { get; set; }
        public Tile Tile { get; set; }

        public TileStateBaseClass(Tile tile)
        {
            Tile = tile;
        }
    }
}