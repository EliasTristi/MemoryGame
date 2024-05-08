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
        public GameObject TileTopFace;

        public void OnPointerDown(PointerEventData eventData)
        {
            Model.Board.BoardState.AddPreview(Model);
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
                StartAnimation();
        }

        private void StartAnimation()
        {
            var animator = GetComponent<Animator>();
            animator.Play("Shown");
        }
    }
}