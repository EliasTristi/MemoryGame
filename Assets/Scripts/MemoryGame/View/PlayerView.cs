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

            Debug.Log(Model.Name);
            var nameUI = _name.GetComponent<TextMeshProUGUI>();
            var scoreUI = _score.GetComponent<TextMeshProUGUI>();
            var elapsedUI = _elapsed.GetComponent<TextMeshProUGUI>();

            switch (e.PropertyName)
            {
                case nameof(Model.Name):
                    nameUI.text = Model.Name;
                    nameUI.color = Color.red;
                    break;
                case nameof(Model.Score):
                    //Debug.Log(Model.Score);
                    scoreUI.text = $"Score: {Model.Score}";
                    break;
                case nameof(Model.Elapsed):
                    elapsedUI.text = $"{Model.MM}:{Model.SS}:{Model.MS}";
                    break;
            }
        }
    }
}