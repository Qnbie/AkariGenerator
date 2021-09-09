﻿using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer), typeof(Collider))]
    public class GoodTileController : TileBase
    {
        public event IsSelectedDelegate OnSelect;

        private bool IsLighted() => _lightCounter > 0;

        private int _lightCounter = 0;
        
        public override bool LightOn()
        {
            _lightCounter++;
            MyTileRenderer.TurnOn();
            return true;
        }

        public override bool LightOff()
        {
            _lightCounter--;
            if (_lightCounter <= 0)
            {
                _lightCounter = 0;
                MyTileRenderer.TurnOff();
            }
            return true;
        }

        public override bool IsValid()
        {
            if (IsLighted() & IsSelected)
                MyTileRenderer.WrongAnim("good wrong");
            if (IsLighted() ^ IsSelected)
                return true;
            return false;
        }

        private void OnMouseDown()
        {
            IsSelected = !IsSelected;
            OnSelect?.Invoke(this);
        }
    }

    public delegate void IsSelectedDelegate(GoodTileController selectedTile);
}