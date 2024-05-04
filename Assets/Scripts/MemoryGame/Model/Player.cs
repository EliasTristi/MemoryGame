using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models
{
    public class Player : ModelBaseClass
    {
        //variables
        private string _name;
        private int _score;
        private bool _isActive;
        private float _elapsed;

        //properties
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                if (_score == value) return;
                _score = value;
                OnPropertyChanged();
            }
        }
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                OnPropertyChanged();
            }
        }
        public float Elapsed
        {
            get => _elapsed;
            set
            {
                if (_elapsed == value) return;
                _elapsed = value;
                OnPropertyChanged();
            }
        }
    }
}