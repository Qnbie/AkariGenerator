using System;
using UnityEngine;
using Utils.Enums;

namespace GameBoard
{
    public class GameBoardStats
    {
        [NonSerialized]
        public readonly Vector2 Size = new Vector2(7, 7);
        
        public readonly TileStates[,] Board = new TileStates[,]
        {
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty, TileStates.Zero,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            { TileStates.One,TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty, TileStates.Four,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty, TileStates.Four,TileStates.Empty,TileStates.Empty, TileStates.Wall},
            {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            {TileStates.Empty,TileStates.Empty, TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        };
        
    }
}