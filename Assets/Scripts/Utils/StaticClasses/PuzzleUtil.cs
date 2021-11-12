using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Utils.StaticClasses
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

        public static RawPuzzle ConvertPuzzleToRawPuzzle(Puzzle puzzle)
        {
            var result = new RawPuzzle
            {
                Size = new Vector2Int(puzzle.SizeX(), puzzle.SizeY()), DifficultyLevel = puzzle.DifficultyLevel
            };
            for (var x = 0; x < puzzle.SizeX(); x++)
            {
                for (var y = 0; y < puzzle.SizeY(); y++)
                {
                    if(puzzle.PuzzleMatrix[x][y] != TileStates.Empty)
                        result.Elements.Add(new Element(new Vector2Int(x,y), puzzle.PuzzleMatrix[x][y]));
                }
            }
            return result;
        }

        public static Puzzle ConvertRawPuzzleToPuzzle(RawPuzzle rawPuzzle)
        {
            var result = new Puzzle(GetEmptyPuzzleMatrix(rawPuzzle.Size), rawPuzzle.DifficultyLevel);
            foreach (var element in rawPuzzle.Elements)
            {
                result.PuzzleMatrix[element.Position.x][element.Position.y] = element.ElementState;
            }
            return result;
        }
    }
}