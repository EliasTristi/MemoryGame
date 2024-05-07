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
            //TODO: implement player view logic

            var nameText = _name.GetComponent<TextMeshProUGUI>().text;
            var scoreText = _score.GetComponent<TextMeshProUGUI>().text;
            var elapsedText = _elapsed.GetComponent<TextMeshProUGUI>().text;

            switch (e.PropertyName)
            {
                case nameof(Model.Name):
                    nameText = Model.Name;
                    break;
                case nameof(Model.Score):
                    scoreText = $"Score: {Model.Score}";
                    break;
                case nameof(Model.Elapsed):
                    elapsedText = $"{Model.MM}:{Model.SS}:{Model.MS}";
                    break;
            }
        }
    }
}