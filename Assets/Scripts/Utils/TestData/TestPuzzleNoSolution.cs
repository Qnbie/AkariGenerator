using System.Collections.Generic;
using Utils.DataStructures;
using Utils.Enums;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Utils.TestData
{
    public static class TestPuzzleNoSolution
    {
        public static readonly Puzzle EasyPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Zero,TileStates.Empty,TileStates.Two,TileStates.Zero,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Four,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.One,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}
        }, Difficulty.Easy);
        
        public static readonly Puzzle NormalPuzzle = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Four,TileStates.Four,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Four,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Three,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Wall,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Wall},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Two,TileStates.Empty,TileStates.Two,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Wall,TileStates.Two,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty}

        }, Difficulty.Medium);
        
                public static readonly Puzzle HardPuzzle = new Puzzle(new List<List<TileStates>>
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
                TileStates.One,TileStates.Two,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Four,TileStates.Empty},
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
                TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Wall,TileStates.Empty,TileStates.Empty,TileStates.Three},
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
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Four,TileStates.Wall,TileStates.Empty,TileStates.Empty,
                TileStates.Empty,TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty},
            new List<TileStates> {
                TileStates.Zero,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Wall,TileStates.Empty,
                TileStates.One,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.Empty,TileStates.One,TileStates.Wall}
        }, Difficulty.Medium);
    }
}