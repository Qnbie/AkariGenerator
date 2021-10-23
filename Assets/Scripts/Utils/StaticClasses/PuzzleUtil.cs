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
            posX >= 0 && posX < sizeX &&
            posY >= 0 && posY <sizeY;
        
        public static bool PlaceIsEqual(Puzzle puzzle, int x, int y, TileStates expectedTile) => 
            IsInTheBoard(x,y, puzzle.SizeX(), puzzle.SizeY()) &&
            puzzle.PuzzleMatrix[x][y] == expectedTile;
        
        public static RawPuzzle ConvertPuzzleToRawPuzzle(Puzzle puzzle)
        {
            RawPuzzle result = new RawPuzzle();
            result.Size = new Vector2Int(puzzle.SizeX(),puzzle.SizeY());
            result.DifficultyLevel = puzzle.PuzzleDifficulty;
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if(puzzle.PuzzleMatrix[x][y] != TileStates.Empty)
                        result.Elements.Add(new Element(new Vector2Int(x,y), puzzle.PuzzleMatrix[x][y]));
                }
            }
            return result;
        }

        public static Puzzle ConvertRawPuzzleToPuzzle(RawPuzzle rawPuzzle)
        {
            Puzzle result = new Puzzle(PuzzleUtil.GetEmptyPuzzleMatrix(rawPuzzle.Size));
            foreach (Element element in rawPuzzle.Elements)
            {
                result.PuzzleMatrix[element.Position.x][element.Position.y] = element.ElementState;
            }
            return result;
        }
        
    }
}