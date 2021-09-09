using System;
using System.Collections.Generic;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard.Tile
{
    public class TileController : MonoBehaviour
    {
        public event IsSelectedDelegate OnSelect;

        public List<TileController> Neighbours = new List<TileController>();
        public TileRenderer MyTileRender { get; set; }
    }

    public delegate void IsSelectedDelegate(TileController selectedTile);
}