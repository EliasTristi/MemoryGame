using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.View
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        [SerializeField] private GameObject _tilePrefab;

        public MemoryBoardView()
        {
            //default
        }

        public void SetUpMemoryBoard(MemoryBoard board, GameObject tilePrefab)
        {

        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: implement Model_PropertyChanged logic
        }
    }
}