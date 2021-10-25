using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Utils.DataStructures
{
    public class Solution: IEquatable<Solution>
    {
        public List<Vector2Int> Positions;

        public int Count => Positions.Count;

        public Solution()
        {
            Positions = new List<Vector2Int>();
        }
        
        public Solution(List<Vector2Int> positions)
        {
            Positions = positions;
        }

        public Vector2Int this[int i]
        {
            get => Positions[i];
            set => Positions[i] = value;
        }
        
        public bool Equals(Solution other)
        {
            if (Positions.Count != other.Positions.Count)
                return false;
            for (int i = 0; i < Positions.Count; i++)
            {
                if (!other.Positions.Contains(Positions[i]))
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Solutions:");
            foreach (var position in Positions)
            {
                stringBuilder.AppendLine($"X > {position.x} Y > {position.y}");
            }
            return stringBuilder.ToString();
        }
    }
}