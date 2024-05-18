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
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            AddAnimationEvents();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Model.Board.BoardState.AddPreview(Model);
            Debug.Log($"Tile State: {Model.State}");
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                StartAnimation();
            }
        }

        private void AddAnimationEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                var clip = _animator.runtimeAnimatorController.animationClips[i];

                AnimationEvent animationStarted = new AnimationEvent();
                animationStarted.time = 0f;
                animationStarted.functionName = nameof(AnimationStartHandler);
                animationStarted.stringParameter = clip.name;

                AnimationEvent animationEnded = new AnimationEvent();
                animationEnded.time = clip.length;
                animationEnded.functionName = nameof(AnimationEndHandler);
                animationEnded.stringParameter = clip.name;

                clip.AddEvent(animationStarted);
                clip.AddEvent(animationEnded);
            }                
        }

        private void AnimationStartHandler()
        {

        }

        private void AnimationEndHandler()
        {
            Model.Board.BoardState.TileAnimationEnded(Model);
        }

        private void StartAnimation()
        {
            var currentState = Model.State.State;

            switch (currentState)
            {
                case TileStates.Hidden:
                    _animator.Play("Hidden");
                    break;
                case TileStates.Found:
                case TileStates.Preview:
                    _animator.Play("Shown");
                    break;
            }
        }
    }
}