using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class BoardStateBaseClass : IBoardState
    {
        public BoardStates State {  get; set; }
        public MemoryBoard Board { get; set; }

        public BoardStateBaseClass(MemoryBoard board)
        {
            Board = board;
        }

        public virtual void AddPreview(Tile tile) { }
        public virtual void TileAnimationEnded(Tile tile) { }
    }
}