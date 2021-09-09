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
        public abstract bool LightOn();
        public abstract void LightOff();
        public abstract bool IsValid();
    }
}