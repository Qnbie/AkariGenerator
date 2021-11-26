using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;

namespace Utils.Helpers
{
    public static class PuzzleUtil
    {
        public static List<List<TileStates>> GetEmptyPuzzleMatrix(Vector2Int size)
        {
            var result = new List<List<TileStates>>();
            for (var i = 0; i < size.x; i++)
            {
                result.Add(new List<TileStates>());
                for (var j = 0; j < size.y; j++)
                {
                    result[i].Add(TileStates.Empty);
                }
            }
            return result;
        }

        public static bool IsInTheBoard(int posX, int posY, int sizeX, int sizeY) =>
            posX >= 0 && posX < sizeX &&
            posY >= 0 && posY <sizeY;
    }
}