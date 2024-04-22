using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public interface IBoardState
    {
        public abstract BoardStates State { get; set; }
        public abstract MemoryBoard Board { get; set; }

        public abstract void AddPreview(Tile tile);
        public abstract void TileAnimationEnded(Tile tile);
    }
}