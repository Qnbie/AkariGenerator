﻿using System.Collections.Generic;
using UnityEngine;

namespace Game.GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public abstract class TileBase : MonoBehaviour
    {
        public bool isSelected;
        public List<TileBase> neighbours;
        public Vector2 Position { get; set; }
        protected TileRenderer MyTileRenderer;

        private void Awake()
        {
            MyTileRenderer = GetComponent<TileRenderer>();
            MyTileRenderer.SetUp();
            neighbours = new List<TileBase>();
            isSelected = false;
        }

        public abstract bool LightOn();
        public abstract bool LightOff();
        public abstract bool IsValid();
    }
}