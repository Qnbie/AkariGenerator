using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Utils.StaticClasses
{
    public static class MapperUtil
    {
        public static readonly Dictionary<Difficulty, Vector2Int> DifficultyToSize =
            new Dictionary<Difficulty, Vector2Int>()
            {
                {Difficulty.Easy, new Vector2Int(7,7)},
                {Difficulty.Medium, new Vector2Int(10,10)},
                {Difficulty.Hard, new Vector2Int(14,14)}
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


        public static double DifToWallNum(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 1.0f;
                case Difficulty.Medium:
                    return 0.5f;
                case Difficulty.Hard:
                    return 0.3f;
                default:
                    return 1.0f;
            }
        }
    }
}