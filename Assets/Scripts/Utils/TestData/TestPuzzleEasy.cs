using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public static class TestPuzzleEasy
    {
        public static readonly Puzzle Puzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Zero,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);

        
        public static readonly Puzzle PreProcessedPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Lit,TileStates.Lit,TileStates.Implacable,TileStates.Implacable,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Lit,TileStates.Lamp,TileStates.Two,TileStates.Zero,TileStates.Implacable},
            new List<TileStates> {TileStates.Implacable,TileStates.One,TileStates.Lamp,TileStates.Four,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates> {TileStates.Empty,TileStates.Implacable,TileStates.Wall,TileStates.Lamp,TileStates.Three,TileStates.Implacable,TileStates.Empty},
            new List<TileStates> {TileStates.Lit,TileStates.Lit,TileStates.Lamp,TileStates.Four,TileStates.Lamp,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Lamp,TileStates.Lit,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Lit,TileStates.Lit,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);

        public static readonly Solution Solution = new Solution(
        new List<Vector2Int>{
            new Vector2Int(0, 1),
            new Vector2Int(1, 3),
            new Vector2Int(2, 2),
            new Vector2Int(2, 4),
            new Vector2Int(3, 0),
            new Vector2Int(3, 3),
            new Vector2Int(3, 6),
            new Vector2Int(4, 2),
            new Vector2Int(4, 4),
            new Vector2Int(5, 3),
            new Vector2Int(6, 1)
        });

        public static readonly Puzzle PlainPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);
    }
}