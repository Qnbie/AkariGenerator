using System.Collections.Generic;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public abstract class TileBase : MonoBehaviour
    {
        public List<TileBase> Neighbours = new List<TileBase>();
        public abstract bool LightOn();
        public abstract void LightOff();
    }
}