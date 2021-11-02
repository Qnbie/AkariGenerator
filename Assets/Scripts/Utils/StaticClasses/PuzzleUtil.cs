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
            result.DifficultyLevel = puzzle.DifficultyLevel;
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
            Puzzle result = new Puzzle(PuzzleUtil.GetEmptyPuzzleMatrix(rawPuzzle.Size), rawPuzzle.DifficultyLevel);
            foreach (Element element in rawPuzzle.Elements)
            {
                result.PuzzleMatrix[element.Position.x][element.Position.y] = element.ElementState;
            }
            return result;
        }
        
        public static Puzzle SetNeighbour(int posX, int posY, TileStates value, Puzzle puzzle)
        {
            if (posX + 1 < puzzle.SizeX() && 
                puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Empty) 
                puzzle.PuzzleMatrix[posX + 1][posY] = value;
            if (posY + 1 < puzzle.SizeY() && 
                puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Empty)
                puzzle.PuzzleMatrix[posX][posY + 1] = value;
            if (posX - 1 >= 0 && 
                puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Empty)
                puzzle.PuzzleMatrix[posX - 1][posY] = value;
            if (posY - 1 >= 0 &&
                puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Empty)
                puzzle.PuzzleMatrix[posX][posY - 1] = value;
            return puzzle;
        }
        
        public static Puzzle TurnOnLamps(Puzzle puzzle, Solution lampPositions)
        {
            puzzle.AddElements(lampPositions.Positions,TileStates.Lamp);
            foreach (Vector2Int lampPos in puzzle.GetElementPositions(TileStates.Lamp))
            {
                bool[] isStop = new bool[4];
                int index = 0;
                while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
                {
                    if (!isStop[0])
                        if( lampPos.x + 1 + index < puzzle.SizeX())
                        {
                            if ((int)puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] < 6)
                                isStop[0] = true;
                            else if (puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Empty ||
                                     puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Implacable)
                                puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[0] = true;
                    if (!isStop[1])
                        if( lampPos.x - 1 - index >= 0)
                        {
                            if ((int)puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] < 6)
                                isStop[1] = true;
                            else if (puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Empty ||
                                     puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Implacable)
                                puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[1] = true;
                    if (!isStop[2])
                        if( lampPos.y + 1 + index < puzzle.SizeY())
                        {
                            if ((int)puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] < 6)
                                isStop[2] = true;
                            else if (puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Empty ||
                                     puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Implacable)
                                puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] = TileStates.Lit;
                        }
                        else isStop[2] = true;
                    if (!isStop[3])
                        if( lampPos.y - 1 - index >= 0)
                        {
                            if ((int)puzzle.PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] < 6)
                                isStop[3] = true;
                            else if (puzzle.PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Empty ||
                                     puzzle.PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Implacable)
                                puzzle.PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] = TileStates.Lit;
                        }
                        else isStop[3] = true;

                    index++;
                }
            }
            return puzzle;
        }
    }
}