using System;
using System.Collections.Generic;
using System.Diagnostics;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard.Tile
{
    public class TileController : MonoBehaviour
    {
        public event IsSelectedDelegate OnSelect;

        public List<TileController> Neighbours = new List<TileController>();
        public Vector2 position;
        public TileRenderer MyTileRender { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsLightedUp { get; set; }

        private void OnMouseDown()
        {
            OnSelect?.Invoke(this);
        }
    }

    public delegate void IsSelectedDelegate(TileController selectedTile);
}