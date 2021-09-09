using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public abstract class TileBase : MonoBehaviour
    {
        public bool IsSelected { get; set; }
        public List<TileBase> neighbours = new List<TileBase>();
        protected TileRenderer MyTileRenderer;

        protected void SetUp()
        {
            MyTileRenderer = GetComponent<TileRenderer>();
            MyTileRenderer.SetUp();
        }

        public abstract bool LightOn();
        public abstract bool LightOff();
        public abstract bool IsValid();
    }
}