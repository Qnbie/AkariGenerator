using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class Validator
    {
        public bool PuzzleIsSolved(Puzzle puzzle, List<Vector2Int> solution)
        {
            Debug.Log(puzzle);
            puzzle = AddLamps(puzzle, solution);
            Debug.Log($"With Lamp :\n {puzzle}");
            if (!CheckRules(puzzle, solution)) return false;
            Debug.Log("Rules are checked");
            var litPuzzle = TurnOnLamps(puzzle, solution);
            Debug.Log($"Lamp Turn On :\n {litPuzzle}");
            foreach (List<TileStates> row in puzzle.PuzzleMatrix)
            {
                foreach (TileStates tileState in row)
                {
                    if (tileState == TileStates.Empty)
                        return false;
                }
            }
            Debug.Log("Solution is ok!");
            return true;
        }

        private Puzzle AddLamps(Puzzle puzzle, List<Vector2Int> solution)
        {
            foreach (Vector2Int lampPos in solution)
            {
                puzzle.PuzzleMatrix[lampPos.x][lampPos.y] = TileStates.Lamp;
            }

            return puzzle;
        }

        private bool CheckRules(Puzzle puzzle, List<Vector2Int> solutions)
        {
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if(puzzle.PuzzleMatrix[x][y] < (TileStates)5)
                        if (!WallIsSatisfied(x, y, puzzle))
                            return false;
                }
            }
            Debug.Log("Walls are satisfied");
            
            for (int i = 0; i < solutions.Count; i++)
            {
                for (int j = i + 1; j < solutions.Count; j++)
                {
                    if (solutions[i].x == solutions[j].x)
                    {
                        if (solutions[i].y < solutions[j].y)
                            CheckForWallY(solutions[i].x, solutions[i].y,solutions[j].y, puzzle);
                        CheckForWallY(solutions[i].x, solutions[j].y,solutions[i].y, puzzle);
                    }
                    else if (solutions[i].y == solutions[j].y)
                    {
                        if (solutions[i].x < solutions[j].x)
                            CheckForWallX(solutions[i].y, solutions[i].x,solutions[j].x, puzzle);
                        CheckForWallX(solutions[i].y, solutions[j].x,solutions[i].x, puzzle);
                    }
                }
            }
            Debug.Log("Lamps are correct");
            
            return true;
        }

        private bool CheckForWallY(int x, int minY, int maxY, Puzzle puzzle)
        {
            for (int y = minY; y < maxY; y++)
                if (puzzle.PuzzleMatrix[x][y] == TileStates.Wall)
                    return true;
            return false;
        }

        private bool CheckForWallX(int y, int minX, int maxX, Puzzle puzzle)
        {
            for (int x = minX; x < maxX; x++)
                if (puzzle.PuzzleMatrix[x][y] == TileStates.Wall)
                    return true;
            return false;
        }
        
        public bool WallIsSatisfied(int posX, int posY, Puzzle puzzle)
        {
            int lampCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Lamp)) lampCnt++;
            return lampCnt == (int) puzzle.PuzzleMatrix[posX][posY];
        }
        
        private Puzzle TurnOnLamps(Puzzle puzzle, List<Vector2Int> solution)
        {
            foreach (Vector2Int lampPos in solution)
            {
                bool[] isStop = new bool[4];
                int index = 0;
                while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
                {
                    if (!isStop[0])
                        if( lampPos.x + 1 + index < puzzle.SizeX())
                        {
                            if (puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Wall)
                                isStop[0] = true;
                            else
                                puzzle.PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[0] = true;
                    if (!isStop[1])
                        if( lampPos.x - 1 - index >= 0)
                        {
                            if (puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Wall)
                                isStop[1] = true;
                            else
                                puzzle.PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[1] = true;
                    if (!isStop[2])
                        if( lampPos.y + 1 + index < puzzle.SizeX())
                        {
                            if (puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Wall)
                                isStop[2] = true;
                            else
                                puzzle.PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] = TileStates.Lit;
                        }
                        else isStop[2] = true;
                    if (!isStop[3])
                        if( lampPos.y - 1 - index >= 0)
                        {
                            if (puzzle.PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Wall)
                                isStop[3] = true;
                            else
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