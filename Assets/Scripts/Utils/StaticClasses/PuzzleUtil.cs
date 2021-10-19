using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Utils.StaticClasses
{
     static class PuzzleUtil
    {
        public static List<List<TileStates>> GetEmptyPuzzle(Vector2Int size)
        {
            List<List<TileStates>> result = new List<List<TileStates>>();
            for (int i = 0; i < size.x; i++)
            {
                result.Add(new List<TileStates>());
                for (int j = 0; j < size.y; j++)
                {
                    result[i].Add(TileStates.Empty);
                }
            }
            return result;
        }

        public static bool IsInTheBoard(int posX, int posY, int sizeX, int sizeY) =>
            posX > 0 && posX < sizeX &&
            posY > 0 && posY <sizeY;
        
        public static bool PlaceIsEqual(List<List<TileStates>> puzzle, int x, int y, TileStates expectedTile) => 
            IsInTheBoard(x,y, puzzle.Count, puzzle[0].Count) &&
            puzzle[x][y] == expectedTile;
    }
}