using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utils.Enums;

namespace Utils.DataStructures
{
    public class RawPuzzle : IEquatable<RawPuzzle>
    {
        public string Key;
        public Vector2Int Size;
        public List<Element> Elements;
        public Difficulty DifficultyLevel;

        public RawPuzzle()
        {
            Key = "";
            Elements = new List<Element>();
            Size = new Vector2Int();
        }
        
        public RawPuzzle(Vector2Int size, List<Element> elements, Difficulty difficulty,  string key)
        {
            Size = size;
            Elements = elements;
            DifficultyLevel = difficulty;
            Key = key;
        }

        public bool Equals(RawPuzzle other)
        {
            if (other == null) return false;
            if (DifficultyLevel != other.DifficultyLevel) return false;
            if ((Size.x != other.Size.x || Size.x != other.Size.y) &&
                (Size.y != other.Size.x || Size.y != other.Size.y)) return false;
            if (Elements.Count != other.Elements.Count) return false;
            foreach (var element in Elements)
            {
                if (!other.Elements.Contains(element)) return false;
            }
            return true;
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