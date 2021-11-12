using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils.Enums;

namespace Utils.DataStructures
{
    public class RawPuzzle : IEquatable<RawPuzzle>
    {
        public Vector2Int Size;
        public readonly List<Element> Elements;
        public Difficulty DifficultyLevel;

        public RawPuzzle()
        {
            Elements = new List<Element>();
            Size = new Vector2Int();
        }
        
        public RawPuzzle(Vector2Int size, List<Element> elements, Difficulty difficulty)
        {
            Size = size;
            Elements = elements;
            DifficultyLevel = difficulty;
        }

        public bool Equals(RawPuzzle other)
        {
            if (other == null) return false;
            if (DifficultyLevel != other.DifficultyLevel) return false;
            if ((Size.x != other.Size.x || Size.x != other.Size.y) &&
                (Size.y != other.Size.x || Size.y != other.Size.y)) return false;
            return Elements.Count == other.Elements.Count && 
                   Elements.All(element => other.Elements.Contains(element));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Difficulty: {DifficultyLevel}");
            stringBuilder.AppendLine($"Size: {Size}");
            foreach (var element in Elements)
            {
                stringBuilder.AppendLine(element.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}