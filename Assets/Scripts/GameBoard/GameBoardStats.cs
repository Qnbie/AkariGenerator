using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.GameBoard
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameBoardStats")]
    public class GameBoardStats : ScriptableObject
    {
        [NonSerialized]
        public readonly Vector2 Size = new Vector2(7, 7);
        [NonSerialized]
        public readonly int[,] Board = new int[,]
        {
            {-1, 1,-1,-1, 5,-1,-1},
            {-1,-1,-1,-1, 1,-1, 0},
            { 1 ,5,-1,-1,-1,-1,-1},
            {-1,-1,-1, 5,-1,-1,-1},
            {-1,-1,-1,-1,-1, 0, 5},
            { 1,-1, 5,-1,-1,-1,-1},
            {-1,-1, 0,-1,-1, 2,-1}
        };
    }
}