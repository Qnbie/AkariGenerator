using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public class TestPuzzleNormal
    {
        public static readonly RawPuzzle RawPuzzle = new RawPuzzle(
            new Vector2Int(10,10),
            new List<Element>()
            {
                new Element(new Vector2Int(0,5),TileStates.Wall),
                new Element(new Vector2Int(1,3),TileStates.Three),
                new Element(new Vector2Int(1,5),TileStates.Wall),
                new Element(new Vector2Int(1,7),TileStates.Four),
                new Element(new Vector2Int(2,1),TileStates.Wall),
                new Element(new Vector2Int(2,3),TileStates.Wall),
                new Element(new Vector2Int(2,6),TileStates.Wall),
                new Element(new Vector2Int(3,2),TileStates.Wall),
                new Element(new Vector2Int(3,7),TileStates.Three),
                new Element(new Vector2Int(3,8),TileStates.Wall),
                new Element(new Vector2Int(4,0),TileStates.Wall),
                new Element(new Vector2Int(4,1),TileStates.Zero),
                new Element(new Vector2Int(5,8),TileStates.Wall),
                new Element(new Vector2Int(5,9),TileStates.Wall),
                new Element(new Vector2Int(6,1),TileStates.Wall),
                new Element(new Vector2Int(6,2),TileStates.Wall),
                new Element(new Vector2Int(6,7),TileStates.Two),
                new Element(new Vector2Int(7,3),TileStates.One),
                new Element(new Vector2Int(7,6),TileStates.Two),
                new Element(new Vector2Int(7,8),TileStates.Two),
                new Element(new Vector2Int(8,2),TileStates.Two),
                new Element(new Vector2Int(8,4),TileStates.Zero),
                new Element(new Vector2Int(8,6),TileStates.Zero),
                new Element(new Vector2Int(9,4),TileStates.Wall),
            },
            Difficulty.Medium,
            "");
        
        public static readonly Puzzle Puzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Three,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Wall,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}

        }, Difficulty.Medium);
        
        public static readonly Puzzle PreProcessedPuzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lamp,TileStates.Lit,TileStates.Wall,TileStates.Lit,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates>() {TileStates.Lit,TileStates.Lit,TileStates.Lamp ,TileStates.Three,TileStates.Lamp,TileStates.Wall,TileStates.Lamp,TileStates.Four,TileStates.Lamp,TileStates.Lit},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall ,TileStates.Lit,TileStates.Wall,TileStates.Lit,TileStates.Empty,TileStates.Wall,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates>() {TileStates.Empty,TileStates.Implacable,TileStates.Wall ,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lamp,TileStates.Three,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Wall,TileStates.Zero ,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lit,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates>() {TileStates.Empty,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Lit,TileStates.Empty,TileStates.Lit,TileStates.Lit,TileStates.Wall,TileStates.Wall},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall ,TileStates.Wall,TileStates.Empty,TileStates.Lit,TileStates.Empty,TileStates.Lit,TileStates.Two,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Lit,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Medium);
        
        public static readonly Solution Solution = new Solution(
            new List<Vector2Int>(){
                new Vector2Int(0, 3),
                new Vector2Int(0, 7),
                new Vector2Int(1, 2),
                new Vector2Int(1, 4),
                new Vector2Int(1, 6),
                new Vector2Int(1, 8),
                new Vector2Int(2, 7),
                new Vector2Int(3, 0),
                new Vector2Int(3, 6),
                new Vector2Int(3, 9),
                new Vector2Int(4, 7),
                new Vector2Int(5, 3),
                new Vector2Int(6, 0),
                new Vector2Int(6, 8),
                new Vector2Int(7, 2),
                new Vector2Int(7, 5),
                new Vector2Int(7, 7),
                new Vector2Int(8, 1),
                new Vector2Int(8, 9),
                new Vector2Int(9, 3),
                new Vector2Int(9, 8),
            });
        
        public static readonly Puzzle PlainPuzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall},
            new List<TileStates>() {TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}

        }, Difficulty.Medium);
    }
}