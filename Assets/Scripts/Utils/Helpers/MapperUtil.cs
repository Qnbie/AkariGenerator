using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Utils.Helpers
{
    public static class MapperUtil
    {

        public static readonly Dictionary<Difficulty, float> MaxWallByDifficulty = new Dictionary<Difficulty, float>
        {
            {Difficulty.Easy, 1.0f},
            {Difficulty.Medium, 0.5f},
            {Difficulty.Hard, 0.3f}
        };

        public static readonly List<Tuple<Difficulty, bool>> DifficultyValues =
            new List<Tuple<Difficulty, bool>>
            {
                new Tuple<Difficulty, bool>(Difficulty.Easy, true),
                new Tuple<Difficulty, bool>(Difficulty.Medium, true),
                new Tuple<Difficulty, bool>(Difficulty.Hard, true)
            };

        public static readonly List<Tuple<Vector2Int, bool>> SizeValues =
            new List<Tuple<Vector2Int, bool>>
            {
                new Tuple<Vector2Int, bool>(new Vector2Int(5, 5), true),
                new Tuple<Vector2Int, bool>(new Vector2Int(7, 7), true),
                new Tuple<Vector2Int, bool>(new Vector2Int(8, 8), true)
            };
    }
}