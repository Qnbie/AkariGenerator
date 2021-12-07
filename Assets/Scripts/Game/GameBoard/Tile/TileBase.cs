using System.Collections.Generic;
using UnityEngine;

namespace Game.GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public abstract class TileBase : MonoBehaviour
    {
        public bool lampPlaced;
        public List<TileBase> neighbours;
        public Vector2 position;
        protected TileRenderer MyTileRenderer;

        private void Awake()
        {
            MyTileRenderer = GetComponent<TileRenderer>();
            MyTileRenderer.SetUp();
            neighbours = new List<TileBase>();
            lampPlaced = false;
        }

        public abstract bool LightOn();
        public abstract bool LightOff();
        public abstract bool IsValid();
    }
}