using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class Validator
    {
        public bool PuzzleIsSolved(Puzzle puzzle, Solution solution)
        {
            puzzle.AddElements(solution.Positions, TileStates.Lamp);
            if (!CheckRules(puzzle))
                return false;
            puzzle.TurnOnLamps(solution);
            var puzzleIsFull = PuzzleIsFull(puzzle);
            puzzle.TurnOfLamps();
            return puzzleIsFull;
        }

        private bool PuzzleIsFull(Puzzle puzzle)
        {
            foreach (List<TileStates> row in puzzle.PuzzleMatrix)
            {
                foreach (TileStates tileState in row)
                {
                    if (tileState == TileStates.Empty || tileState == TileStates.Implacable)
                        return false;
                }
            }
            return true;
        }
        
        private bool CheckRules(Puzzle puzzle)
        {
            if (!LampsCheck(puzzle, new Solution(puzzle.GetElementPositions(TileStates.Lamp))))
                return false;
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if((int)puzzle.PuzzleMatrix[x][y] < 5)
                        if (!WallIsSatisfied(x, y, puzzle))
                            return false;
                }
            }
            
            return true;
        }

        public bool LampsCheck(Puzzle puzzle, Solution solution)
        {
            for (int i = 0; i < solution.Count; i++)
            {
                for (int j = i + 1; j < solution.Count; j++)
                {
                    if (solution[i].x == solution[j].x)
                    {
                        if (solution[i].y < solution[j].y)
                        {
                            if (!LampsAreCorrectY(solution[i].x, solution[i].y, solution[j].y, puzzle))
                                return false;
                        }
                        else if (!LampsAreCorrectY(solution[i].x, solution[j].y, solution[i].y, puzzle))
                            return false;
                    }
                    else if (solution[i].y == solution[j].y)
                    {
                        if (solution[i].x < solution[j].x)
                        {
                            if (!LampsAreCorrectX(solution[i].y, solution[i].x, solution[j].x, puzzle))
                                return false;
                        }
                        else if (!LampsAreCorrectX(solution[i].y, solution[j].x, solution[i].x, puzzle))
                            return false;
                    }
                }
            }

            return true;
        }
        
        private bool LampsAreCorrectY(int x, int minY, int maxY, Puzzle puzzle)
        {
            for (int y = minY; y < maxY; y++)
                if ((int)puzzle.PuzzleMatrix[x][y] < 6)
                    return true;
            return false;
        }

        private bool LampsAreCorrectX(int y, int minX, int maxX, Puzzle puzzle)
        {
            for (int x = minX; x < maxX; x++)
                if ((int)puzzle.PuzzleMatrix[x][y] < 6)
                    return true;
            return false;
        }
        
        public bool WallIsSatisfied(int posX, int posY, Puzzle puzzle)
        {
            int lampCnt = 0;
            if (puzzle.PlaceIsEqual(posX + 1, posY, TileStates.Lamp)) lampCnt++;
            if (puzzle.PlaceIsEqual(posX - 1, posY, TileStates.Lamp)) lampCnt++;
            if (puzzle.PlaceIsEqual(posX, posY + 1, TileStates.Lamp)) lampCnt++;
            if (puzzle.PlaceIsEqual(posX, posY - 1, TileStates.Lamp)) lampCnt++;
            if (lampCnt == (int) puzzle.PuzzleMatrix[posX][posY])
                return true;
            return false;
        }
    }
}