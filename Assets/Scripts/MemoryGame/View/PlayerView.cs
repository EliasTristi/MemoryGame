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

        private string _nameText;
        private string _scoreText;
        private string _elapsedText;
        private bool _isActive;

        public PlayerView()
        {
            _nameText = _name.GetComponent<TextMeshProUGUI>().text;
            _scoreText = _score.GetComponent<TextMeshProUGUI>().text;
            _elapsedText = _elapsed.GetComponent<TextMeshProUGUI>().text;

            Model = new Player(_nameText, int.Parse(_scoreText), _isActive, float.Parse(_elapsedText));
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: implement player view logic

            
        }
    }
}