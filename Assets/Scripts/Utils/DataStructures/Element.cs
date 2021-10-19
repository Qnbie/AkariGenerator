using Enums;
using UnityEngine;

namespace Utils.DataStructures
{
    public class Element
    {
        public Vector2Int Position;
        public TileStates ElementState;

        public Element(Vector2Int position, TileStates elementState)
        {
            Position = position;
            ElementState = elementState;
        }
    }
}