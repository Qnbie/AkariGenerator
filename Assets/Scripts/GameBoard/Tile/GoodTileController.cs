using System;
using System.Collections.Generic;
using System.Diagnostics;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public class GoodTileController : TileBase
    {
        public event IsSelectedDelegate OnSelect;

        public Vector2 position;
        public TileRenderer MyTileRender { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsLighted { get; set; }

        public override bool LightOn()
        {
            return true;
        }

        public override void LightOff()
        {
            
        }
        
        private void OnMouseDown() => OnSelect?.Invoke(this);
    }

    public delegate void IsSelectedDelegate(GoodTileController selectedTile);
}