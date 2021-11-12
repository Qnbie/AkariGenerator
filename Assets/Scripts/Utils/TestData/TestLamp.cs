using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.TestData
{
    public static class TestLamp
    {
        public static readonly List<Puzzle> GoodYPuzzles = new List<Puzzle>
        {
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Wall},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty}
            }),
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Four},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty}
            }),
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Zero},
                new List<TileStates> {TileStates.Empty},
                new List<TileStates> {TileStates.Empty}
            })
        };

        public static readonly Puzzle BadYPuzzles = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty},
            new List<TileStates> {TileStates.Empty},
            new List<TileStates> {TileStates.Empty},
            new List<TileStates> {TileStates.Empty},
            new List<TileStates> {TileStates.Empty}
        });
        
        public static readonly List<Solution> YSolutions = new List<Solution>
        {
            new Solution(new List<Vector2Int>
            {
                new Vector2Int(0,0),
                new Vector2Int(4,0)
            }),
            new Solution(new List<Vector2Int>
            {
                new Vector2Int(1,0),
                new Vector2Int(3,0)
            })
        };
        
        public static readonly List<Puzzle> GoodXPuzzles = new List<Puzzle>
        {
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty, TileStates.Empty, TileStates.Wall, TileStates.Empty, TileStates.Empty}
            }),
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty, TileStates.Empty, TileStates.Four, TileStates.Empty, TileStates.Empty}
            }),
            new Puzzle(new List<List<TileStates>>
            {
                new List<TileStates> {TileStates.Empty,TileStates.Empty,TileStates.Zero,TileStates.Empty,TileStates.Empty}
            })
        };

        public static readonly Puzzle BadXPuzzles = new Puzzle(new List<List<TileStates>>
        {
            new List<TileStates> {TileStates.Empty, TileStates.Empty, TileStates.Empty, TileStates.Empty, TileStates.Empty}
        });
        
        public static readonly List<Solution> XSolutions = new List<Solution>
        {
            new Solution(new List<Vector2Int>
            {
                new Vector2Int(0,0),
                new Vector2Int(0,4)
            }),
            new Solution(new List<Vector2Int>
            {
                new Vector2Int(0,1),
                new Vector2Int(0,3)
            })
        };
    }
}