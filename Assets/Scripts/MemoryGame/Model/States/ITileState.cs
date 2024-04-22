using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public interface ITileState
    {
        public TileStates State { get; }
        public Tile Tile { get; set; }
    }
}