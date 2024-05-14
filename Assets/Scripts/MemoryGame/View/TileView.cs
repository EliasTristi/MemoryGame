using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Models;
using System.ComponentModel;
using UnityEngine.EventSystems;
using System;
using Memory.Models.States;

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
            {
                StartCoroutine(StartAnimation());
                Model.Board.BoardState.TileAnimationEnded(Model);
            }
        }

        private IEnumerator StartAnimation()
        {
            var animator = GetComponent<Animator>();
            
            if (animator == null) yield break;

            var currentState = Model.State.State;

            switch (currentState)
            {
                case TileStates.Hidden:
                    animator.Play("Hidden");
                    break;
                case TileStates.Preview:
                    animator.Play("Shown");
                    break;
            }

            animator.Update(0);

            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f || animator.IsInTransition(0))
            {
                yield return null;
            }
        }
    }
}