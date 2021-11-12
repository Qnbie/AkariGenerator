using System;
using UnityEngine;
using Utils.Enums;

namespace Utils.DataStructures
{
    public class Element : IEquatable<Element>
    {
        public Vector2Int Position;
        public readonly TileStates ElementState;

        public Element(Vector2Int position, TileStates elementState)
        {
            Position = position;
            ElementState = elementState;
        }

        public bool Equals(Element other)
        {
            return other != null && 
                   ElementState == other.ElementState && 
                   (Position.x == other.Position.x || Position.x == other.Position.y) && 
                   (Position.y == other.Position.x || Position.y == other.Position.y);
        }

        public override string ToString()
        {
            return $"ElementType: {ElementState} ElementPos:{Position.ToString()}";
        }
    }
}