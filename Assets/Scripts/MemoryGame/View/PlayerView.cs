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
        //inspector variables
        [SerializeField] private GameObject _name;
        [SerializeField] private GameObject _score;
        [SerializeField] private GameObject _elapsed;

        //variables
        private TextMeshProUGUI _nameUI;
        private TextMeshProUGUI _scoreUI;
        private TextMeshProUGUI _elapsedUI;

        private void Start()
        {
            _nameUI = _name.GetComponent<TextMeshProUGUI>();
            _scoreUI = _score.GetComponent<TextMeshProUGUI>();
            _elapsedUI = _elapsed.GetComponent<TextMeshProUGUI>();

            _nameUI.text = Model.Name;
            _scoreUI.text = $"Score: {Model.Score}";
            _elapsedUI.text = $"{Model.MM}:{Model.SS}:{Model.MS}";

            if (Model.IsActivePlayer)
                _nameUI.color = Color.red;
        }

        private void Update()
        {
            //CHECK: can be changed to normal method and put into memory game update

            if (Model.IsActivePlayer)
            {
                Model.Elapsed += Time.deltaTime;
            }
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Model.Name):
                    _nameUI.text = Model.Name;
                    break;
                case nameof(Model.Score):
                    //Debug.Log(Model.Score);
                    _scoreUI.text = $"Score: {Model.Score}";
                    break;
                case nameof(Model.Elapsed):
                    _elapsedUI.text = $"{Model.MM}:{Model.SS}:{Model.MS}";
                    break;
                case nameof(Model.IsActivePlayer):
                    if (Model.IsActivePlayer) 
                        _nameUI.color = Color.red;
                    else
                        _nameUI.color = Color.white;
                    break;
            }
        }
    }
}