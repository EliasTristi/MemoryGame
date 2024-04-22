using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public interface ITileState
    {
        public abstract TileStates State { get; }
        public abstract Tile Tile { get; set; }
    }
}