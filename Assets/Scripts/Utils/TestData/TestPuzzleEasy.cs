using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public static class TestPuzzleEasy
    {
        public static readonly RawPuzzle RawPuzzle = new RawPuzzle(
            new Vector2Int(7,7),
            new List<Element>()
            {
                new Element(new Vector2Int(1,1),TileStates.Wall),
                new Element(new Vector2Int(1,4),TileStates.Two),
                new Element(new Vector2Int(1,5),TileStates.Zero),
                new Element(new Vector2Int(2,1),TileStates.One),
                new Element(new Vector2Int(2,3),TileStates.Four),
                new Element(new Vector2Int(3,2),TileStates.Wall),
                new Element(new Vector2Int(3,4),TileStates.Three),
                new Element(new Vector2Int(4,3),TileStates.Four),
                new Element(new Vector2Int(4,5),TileStates.Wall),
                new Element(new Vector2Int(5,1),TileStates.One),
                new Element(new Vector2Int(5,2),TileStates.Wall),
                new Element(new Vector2Int(5,5),TileStates.Wall),
            },
            Difficulty.Easy,
            "");

        public static readonly Puzzle Puzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Zero,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);
        
        public static readonly Puzzle PreProcessedPuzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Lamp,TileStates.Two,TileStates.Zero,TileStates.Implacable},
            new List<TileStates>() {TileStates.Empty,TileStates.One,TileStates.Lamp,TileStates.Four,TileStates.Lamp,TileStates.Implacable,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Lamp,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Lamp,TileStates.Four,TileStates.Lamp,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Lamp,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);

        public static readonly Solution Solution = new Solution(
        new List<Vector2Int>(){
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
            new Vector2Int(6, 1),
        });
    }
}