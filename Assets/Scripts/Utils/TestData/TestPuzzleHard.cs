using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public static class TestPuzzleHard
    {
       public static readonly Puzzle Puzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {
                TileStates.Zero,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Zero,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.One,TileStates.Two,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Zero,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.One,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Zero,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.One,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall}
        }, Difficulty.Hard);
        
        public static readonly Puzzle PreProcessedPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {
                TileStates.Zero,TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Zero,
                TileStates.Implacable,TileStates.Wall,TileStates.Implacable,TileStates.Empty,TileStates.Lit,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Implacable,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Implacable,
                TileStates.Empty,TileStates.Lit,TileStates.Zero,TileStates.Implacable,TileStates.Lit,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Lit,
                TileStates.Lit,TileStates.Lamp,TileStates.Lit,TileStates.One,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.One,TileStates.Two,TileStates.Implacable,TileStates.Zero,TileStates.Lit,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit,
                TileStates.Lit,TileStates.Lamp,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit},
            new List<TileStates> {
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Lit,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Zero,TileStates.Implacable},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.One,TileStates.Empty,
                TileStates.Empty,TileStates.Lit,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.One},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Wall,TileStates.Lit,TileStates.Lit,TileStates.Lamp},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,
                TileStates.Empty,TileStates.Implacable,TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Implacable,TileStates.Zero,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.One,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Implacable,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall}
        }, Difficulty.Hard);
        
        public static readonly Solution Solution = new Solution(
            new List<Vector2Int>{
                new Vector2Int(0, 3),
                new Vector2Int(0, 10),
                new Vector2Int(1, 2),
                new Vector2Int(1, 7),
                new Vector2Int(1, 12),
                new Vector2Int(2, 0),
                new Vector2Int(2, 8),
                new Vector2Int(2, 11),
                new Vector2Int(3, 1),
                new Vector2Int(3, 6),
                new Vector2Int(3, 13),
                new Vector2Int(4, 8),
                new Vector2Int(5, 1),
                new Vector2Int(5, 4),
                new Vector2Int(5, 10),
                new Vector2Int(6, 2),
                new Vector2Int(6, 9),
                new Vector2Int(7, 5),
                new Vector2Int(7, 13),
                new Vector2Int(8, 0),
                new Vector2Int(8, 3),
                new Vector2Int(8, 7),
                new Vector2Int(8, 12),
                new Vector2Int(9, 11),
                new Vector2Int(10, 2),
                new Vector2Int(10, 8),
                new Vector2Int(10, 13),
                new Vector2Int(11, 1),
                new Vector2Int(11, 6),
                new Vector2Int(11, 10),
                new Vector2Int(12, 3),
                new Vector2Int(12, 5),
                new Vector2Int(12, 12),
                new Vector2Int(13, 4),
                new Vector2Int(13, 8)
            });
        
        public static readonly Puzzle PlainPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {
                TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Two,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Wall,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall}
        }, Difficulty.Hard);
    }
}