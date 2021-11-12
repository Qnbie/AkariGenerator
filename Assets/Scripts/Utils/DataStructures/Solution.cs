using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utils.DataStructures
{
    public class Solution: IEquatable<Solution>
    {
        public readonly List<Vector2Int> Positions;

        public int Count => Positions.Count;

         public Solution()
        {
            Positions = new List<Vector2Int>();
        }
        
        public Solution(Solution solution)
        {
            Positions = new List<Vector2Int>();
            Positions.AddRange(solution.Positions);
        }
        
        public Solution(List<Vector2Int> positions)
        {
            Positions = positions;
        }

        public Vector2Int this[int i] => Positions[i];

        public bool Equals(Solution other)
        {
            if (other == null)
                return false;
            return Positions.Count == other.Positions.Count && 
                   Positions.All(position => other.Positions.Contains(position));
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