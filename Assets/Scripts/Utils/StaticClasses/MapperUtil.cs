using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Utils.StaticClasses
{
    public static class MapperUtil
    {
        public static double MaxWallByDifficulty(Difficulty difficulty)
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