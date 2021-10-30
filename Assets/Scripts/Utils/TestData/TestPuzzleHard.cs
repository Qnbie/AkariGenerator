using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public class TestPuzzleHard
    {
        public static readonly RawPuzzle RawPuzzle = new RawPuzzle(
            new Vector2Int(14,14),
            new List<Element>()
            {
                new Element(new Vector2Int(0,0),TileStates.Zero),
                new Element(new Vector2Int(0,1),TileStates.Zero),
                new Element(new Vector2Int(0,6),TileStates.Zero),
                new Element(new Vector2Int(0,8),TileStates.Wall),
                new Element(new Vector2Int(0,13),TileStates.Wall),
                
                new Element(new Vector2Int(1,5),TileStates.Wall),
                new Element(new Vector2Int(1,9),TileStates.Zero),
                new Element(new Vector2Int(1,13),TileStates.Wall),
                
                new Element(new Vector2Int(2,5),TileStates.Wall),
                new Element(new Vector2Int(2,10),TileStates.One),

                new Element(new Vector2Int(3,2),TileStates.One),
                new Element(new Vector2Int(3,3),TileStates.Wall),
                new Element(new Vector2Int(3,7),TileStates.One),
                new Element(new Vector2Int(3,8),TileStates.Two),
                new Element(new Vector2Int(3,10),TileStates.Zero),

                new Element(new Vector2Int(4,1),TileStates.Wall),

                new Element(new Vector2Int(5,0),TileStates.One),
                new Element(new Vector2Int(5,3),TileStates.One),
                new Element(new Vector2Int(5,7),TileStates.Wall),
                new Element(new Vector2Int(5,11),TileStates.One),
                new Element(new Vector2Int(5,12),TileStates.Zero),

                new Element(new Vector2Int(6,3),TileStates.One),
                new Element(new Vector2Int(6,5),TileStates.One),
                new Element(new Vector2Int(6,13),TileStates.One),

                new Element(new Vector2Int(7,0),TileStates.Wall),
                new Element(new Vector2Int(7,8),TileStates.Zero),
                new Element(new Vector2Int(7,10),TileStates.Wall),

                new Element(new Vector2Int(8,1),TileStates.Wall),
                new Element(new Vector2Int(8,2),TileStates.One),
                new Element(new Vector2Int(8,6),TileStates.One),
                new Element(new Vector2Int(8,10),TileStates.Zero),
                new Element(new Vector2Int(8,13),TileStates.Wall),

                new Element(new Vector2Int(9,12),TileStates.Two),

                new Element(new Vector2Int(10,3),TileStates.One),
                new Element(new Vector2Int(10,5),TileStates.Zero),
                new Element(new Vector2Int(10,6),TileStates.One),
                new Element(new Vector2Int(10,10),TileStates.One),
                new Element(new Vector2Int(10,11),TileStates.One),

                new Element(new Vector2Int(11,3),TileStates.One),
                new Element(new Vector2Int(11,8),TileStates.One),

                new Element(new Vector2Int(12,0),TileStates.Zero),
                new Element(new Vector2Int(12,4),TileStates.Wall),
                new Element(new Vector2Int(12,8),TileStates.One),

                new Element(new Vector2Int(13,0),TileStates.Zero),
                new Element(new Vector2Int(13,5),TileStates.Wall),
                new Element(new Vector2Int(13,7),TileStates.One),
                new Element(new Vector2Int(13,12),TileStates.One),
                new Element(new Vector2Int(13,13),TileStates.Wall),

            },
            Difficulty.Hard,
            "");
        
        public static readonly Puzzle Puzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {
                TileStates.Zero,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Zero,
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.One,TileStates.Two,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Zero,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.One,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One},
            new List<TileStates>() {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Wall,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Zero,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.One,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall}
        }, Difficulty.Hard);
        
        public static readonly Puzzle PreProcessedPuzzle = new Puzzle(new List<List<TileStates>>()
        {
            new List<TileStates>() {
                TileStates.Zero,TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Zero,
                TileStates.Implacable,TileStates.Wall,TileStates.Implacable,TileStates.Empty,TileStates.Lit,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Implacable,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Implacable,
                TileStates.Empty,TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Lit,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.One,TileStates.Lamp,TileStates.Lit,TileStates.Lit},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.One,TileStates.Two,TileStates.Implacable,TileStates.Zero,TileStates.Lit,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Lit,TileStates.Implacable,TileStates.Empty},
            new List<TileStates>() {
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Zero,TileStates.Implacable},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.One,TileStates.Empty,
                TileStates.Empty,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.One},
            new List<TileStates>() {
                TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,
                TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Wall,TileStates.Lit,TileStates.Lit,TileStates.Lamp},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Wall,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,
                TileStates.Empty,TileStates.Implacable,TileStates.Implacable,TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Wall},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Empty,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Implacable,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Implacable,TileStates.Zero,TileStates.One,
                TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.One,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Implacable,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates>() {
                TileStates.Zero,TileStates.Implacable,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall}
        }, Difficulty.Hard);
        
        public static readonly Solution Solution = new Solution(
            new List<Vector2Int>(){
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
                new Vector2Int(13, 8),
            });
    }
}