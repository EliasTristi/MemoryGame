using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

namespace Memory.View
{
    public class PlayerView : ViewBaseClass<Player>
    {
        [SerializeField] private GameObject _name;
        [SerializeField] private GameObject _score;
        [SerializeField] private GameObject _elapsed;

        private TextMeshProUGUI _nameText;
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _elapsedText;

        public PlayerView()
        {
            Model = new Player();
        }

        private void Start()
        {
            _nameText = _name.GetComponent<TextMeshProUGUI>();
            _scoreText = _score.GetComponent<TextMeshProUGUI>();
            _elapsedText = _elapsed.GetComponent<TextMeshProUGUI>();
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: implement player view logic
        }
    }
}