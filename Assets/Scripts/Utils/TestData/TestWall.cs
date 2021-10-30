using System.Collections.Generic;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public class TestWall
    {
        public static readonly List<Puzzle> GoodWalls = new List<Puzzle>()
        {
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
                new List<TileStates>() {TileStates.Empty, TileStates.Zero, TileStates.Empty},
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Empty, TileStates.One, TileStates.Empty},
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
                new List<TileStates>() {TileStates.Empty, TileStates.Two, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Three, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Four, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
        };
        
        public static readonly List<Puzzle> BadWalls = new List<Puzzle>()
        {
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Empty, TileStates.Zero, TileStates.Empty},
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Empty, TileStates.One, TileStates.Empty},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Empty, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Two, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Three, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
            new Puzzle(new List<List<TileStates>>()
            {
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
                new List<TileStates>() {TileStates.Lamp, TileStates.Four, TileStates.Empty},
                new List<TileStates>() {TileStates.Lamp, TileStates.Lamp, TileStates.Lamp},
            }),
        };
    }
}