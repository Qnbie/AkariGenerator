using System;
using UnityEngine;
using Utils.Enums;

namespace Utils.DataStructures
{
    public class Element : IEquatable<Element>
    {
        public Vector2Int Position;
        public TileStates ElementState;

        public Element(){}
        public Element(Vector2Int position, TileStates elementState)
        {
            Position = position;
            ElementState = elementState;
        }

        public bool Equals(Element other)
        {
            return other != null && 
                   this.ElementState == other.ElementState && 
                   (this.Position.x == other.Position.x || this.Position.x == other.Position.y) && 
                   (this.Position.y == other.Position.x || this.Position.y == other.Position.y);
        }

        public override string ToString()
        {
            return $"ElementType: {ElementState} ElementPos:{Position.ToString()}";
        }
    }
}