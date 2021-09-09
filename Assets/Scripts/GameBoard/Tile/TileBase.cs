using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public abstract class TileBase : MonoBehaviour
    {
        public bool IsSelected { get; protected set; }
        public List<TileBase> Neighbours { get; private set; }
        public Vector2 Position { get; set; }
        protected TileRenderer MyTileRenderer;

        private void Awake()
        {
            MyTileRenderer = GetComponent<TileRenderer>();
            MyTileRenderer.SetUp();
            Neighbours = new List<TileBase>();
            IsSelected = false;
        }

        public abstract bool LightOn();
        public abstract bool LightOff();
        public abstract bool IsValid();
    }
}