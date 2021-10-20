using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;
using Utils.StaticClasses;

namespace Source.Algorithms
{
    public class Validator
    {
        public bool PuzzleIsSolved(List<List<TileStates>> puzzle, List<Vector2Int> solution)
        {
            puzzle = AddLamps(puzzle, solution);
            if (CheckRules(puzzle, solution)) return false;
            var litPuzzle = TurnOnLamps(puzzle, solution);
            foreach (List<TileStates> row in puzzle)
            {
                foreach (TileStates tileState in row)
                {
                    if (tileState == TileStates.Empty)
                        return false;
                }
            }
            return true;
        }

        private List<List<TileStates>> AddLamps(List<List<TileStates>> puzzle, List<Vector2Int> solution)
        {
            foreach (Vector2Int lampPos in solution)
            {
                puzzle[lampPos.x][lampPos.y] = TileStates.Lamp;
            }

            return puzzle;
        }

        private bool CheckRules(List<List<TileStates>> puzzle, List<Vector2Int> solutions)
        {
            for (int x = 0; x < puzzle.Count; x++)
            {
                for (int y = 0; y < puzzle[0].Count; y++)
                {
                    if(puzzle[x][y] < (TileStates)5)
                        if (!WallIsSatisfied(x, y, puzzle))
                            return false;
                }
            }

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
            return true;
        }

        private bool CheckForWallY(int x, int minY, int maxY, List<List<TileStates>> puzzle)
        {
            for (int y = minY; y < maxY; y++)
                if (puzzle[x][y] == TileStates.Wall)
                    return true;
            return false;
        }

        private bool CheckForWallX(int y, int minX, int maxX, List<List<TileStates>> puzzle)
        {
            for (int x = minX; x < maxX; x++)
                if (puzzle[x][y] == TileStates.Wall)
                    return true;
            return false;
        }
        
        public bool WallIsSatisfied(int posX, int posY, List<List<TileStates>> puzzle)
        {
            int lampCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Lamp)) lampCnt++;
            return lampCnt == (int) puzzle[posX][posY];
        }
        
        private List<List<TileStates>> TurnOnLamps(List<List<TileStates>> puzzle, List<Vector2Int> solution)
        {
            foreach (Vector2Int lampPos in solution)
            {
                bool[] isStop = new bool[4];
                int index = 0;
                while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
                {
                    if (!isStop[0])
                        if( lampPos.x + 1 + index < puzzle.Count)
                        {
                            if (puzzle[lampPos.x + 1 + index][lampPos.y] == TileStates.Wall)
                                isStop[0] = true;
                            else
                                puzzle[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[0] = true;
                    if (!isStop[1])
                        if( lampPos.x - 1 - index > 0)
                        {
                            if (puzzle[lampPos.x - 1 - index][lampPos.y] == TileStates.Wall)
                                isStop[1] = true;
                            else
                                puzzle[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[1] = true;
                    if (!isStop[2])
                        if( lampPos.y + 1 + index < puzzle.Count)
                        {
                            if (puzzle[lampPos.x][lampPos.y + 1 + index] == TileStates.Wall)
                                isStop[2] = true;
                            else
                                puzzle[lampPos.x][lampPos.y + 1 + index] = TileStates.Lit;
                        }
                        else isStop[2] = true;
                    if (!isStop[3])
                        if( lampPos.y - 1 - index > 0)
                        {
                            if (puzzle[lampPos.x][lampPos.y - 1 - index] == TileStates.Wall)
                                isStop[3] = true;
                            else
                                puzzle[lampPos.x][lampPos.y - 1 - index] = TileStates.Lit;
                        }
                        else isStop[3] = true;
                }
            }

            return puzzle;
        }
    }
}