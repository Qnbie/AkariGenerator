using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.GameBoard
{
    public class GameBoardStats
    {
        [NonSerialized]
        public readonly Vector2 Size = new Vector2(7, 7);
        
        public readonly int[,] Board = new int[,]
        {
            {-1,-1,-1,-1, 0,-1,-1},
            {-1,-1,-1,-1,-1,-1,-1},
            { 3,-1,-1, 5,-1,-1,-1},
            {-1,-1, 5,-1, 4,-1,-1},
            {-1,-1,-1, 4,-1,-1, 5},
            {-1,-1,-1,-1,-1,-1,-1},
            {-1,-1, 5,-1,-1,-1,-1}
        };
    }
}