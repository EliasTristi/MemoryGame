using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Models;
using System.ComponentModel;
using UnityEngine.EventSystems;
using System;

namespace Memory.View
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {
        public TileView()
        {
            //default
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(Model.State);



            Model.Board.BoardState.AddPreview(Model);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
                StartAnimation();
        }

        private void StartAnimation()
        {
            Debug.Log("Animation started");
        }
    }
}