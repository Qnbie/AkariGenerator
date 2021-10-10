using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.GameBoard
{
    public class GameBoardStats
    {
        [NonSerialized]
        public readonly Vector2 Size = new Vector2(7, 7);
        
        public readonly TileStates[,] Board = new TileStates[,]
        {
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty, TileStates.Zero,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            { TileStates.Three,TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty, TileStates.Four,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty, TileStates.Four,TileStates.Empty,TileStates.Empty, TileStates.Wall},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        };
        
    }
    public enum TileStates
        {
            Zero = 0, One = 1, Two = 2, Three = 3, Four = 4,
            Empty, Wall,
            Implacable
        }
}