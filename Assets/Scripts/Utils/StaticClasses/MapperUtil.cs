using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Utils.StaticClasses
{
    public static class MapperUtil
    {
        public static readonly Dictionary<Difficulty, Vector2Int> DifficultyToSize =
            new Dictionary<Difficulty, Vector2Int>()
            {
                {Difficulty.Easy, new Vector2Int(5,5)},
                {Difficulty.Medium, new Vector2Int(10,10)},
                {Difficulty.Hard, new Vector2Int(15,15)}
            };

        public static Difficulty DifficultyFromLevel(int level)
        {
            if (level < 5)
            {
                return Difficulty.Hard;
            }

            if (level < 10)
            {
                return Difficulty.Medium;
            }

            return Difficulty.Easy;
        }
    }
}