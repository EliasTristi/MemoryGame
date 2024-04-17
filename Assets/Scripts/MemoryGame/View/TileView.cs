using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Memory.Models;
using System.ComponentModel;
using UnityEngine.EventSystems;

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
            //TODO: implement OnPointerDown logic
        }

        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: implement Model_PropertyChanged logic
        }
    }
}