using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public static class TestPuzzles
    {
        public static RawPuzzle GoodRawPuzzle = new RawPuzzle(
            new Vector2Int(7,7),
            new List<Element>()
            {
                new Element(new Vector2Int(0,3),TileStates.Wall),
                new Element(new Vector2Int(0,4),TileStates.Wall),
                new Element(new Vector2Int(2,0),TileStates.Wall),
                new Element(new Vector2Int(3,0),TileStates.Wall),
                new Element(new Vector2Int(3,3),TileStates.Wall),
                new Element(new Vector2Int(3,6),TileStates.Wall),
                new Element(new Vector2Int(4,6),TileStates.Wall),
                new Element(new Vector2Int(6,2),TileStates.Wall),
                new Element(new Vector2Int(6,3),TileStates.Wall)
            },
            Difficulty.Medium,
            "");

        public static Puzzle GoodPuzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Two,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.One},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        });

        public static List<Vector2Int> GoodSolution = new List<Vector2Int>()
        {
            new Vector2Int(0,6),
            new Vector2Int(1,0),
            new Vector2Int(2,1),
            new Vector2Int(3,5),
            new Vector2Int(4,3),
            new Vector2Int(5,2),
            new Vector2Int(6,0),
            new Vector2Int(6,4),
        };
    }
}