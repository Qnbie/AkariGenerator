using System.Collections.Generic;
using UnityEngine;

namespace Utils.DataStructures
{
    public class RawPuzzle
    {
        public string Key;
        public Vector2Int Size;
        public List<Element> Elements;
        public double Difficulty;
    }
}