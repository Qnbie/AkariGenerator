﻿using System.Collections.Generic;
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
            puzzle.AddLamps(solution.Positions);
            if (!CheckRules(puzzle))
                return false;
            var litPuzzle = puzzle.TurnOnLamps();
            if (PuzzleIsFull(litPuzzle))
            {
                Debug.Log($"Puzzle is solved");
                return true;
            }
            Debug.Log($"Puzzle is not solved");
            return false;
        }

        private bool PuzzleIsFull(Puzzle puzzle)
        {
            foreach (List<TileStates> row in puzzle.PuzzleMatrix)
            {
                foreach (TileStates tileState in row)
                {
                    if (tileState == TileStates.Empty)
                    {
                        Debug.Log("Puzzle is NOT Fully solved");
                        return false;
                    }
                }
            }
            Debug.Log("Puzzle is Fully solved");
            return true;
        }
        
        private bool CheckRules(Puzzle puzzle)
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
            
            return LampsCheck(puzzle, new Solution(puzzle.GetLampPositions()));
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
                            if (CheckForWallY(solution[i].x, solution[i].y, solution[j].y, puzzle))
                                return false;
                        }
                        else if (CheckForWallY(solution[i].x, solution[j].y, solution[i].y, puzzle))
                            return false;
                    }
                    else if (solution[i].y == solution[j].y)
                    {
                        if (solution[i].x < solution[j].x)
                        {
                            if (CheckForWallX(solution[i].y, solution[i].x, solution[j].x, puzzle))
                                return false;
                        }
                        else if (CheckForWallX(solution[i].y, solution[j].x, solution[i].x, puzzle))
                            return false;
                    }
                }
            }

            Debug.Log("Lamp positions are correct");
            return false;
        }
        
        private bool CheckForWallY(int x, int minY, int maxY, Puzzle puzzle)
        {
            for (int y = minY; y < maxY; y++)
                if ((int)puzzle.PuzzleMatrix[x][y] < 6)
                {
                    Debug.Log($"Lamps at ({x},{minY}) and ({x},{maxY}) are failed");
                    return true;
                }
            return false;
        }

        private bool CheckForWallX(int y, int minX, int maxX, Puzzle puzzle)
        {
            for (int x = minX; x < maxX; x++)
                if ((int)puzzle.PuzzleMatrix[x][y] < 6)
                {
                    Debug.Log($"Lamps at ({minX},{y}) and ({maxX},{y}) are failed");
                    return true;
                }
            return false;
        }
        
        public bool WallIsSatisfied(int posX, int posY, Puzzle puzzle)
        {
            int lampCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Lamp)) lampCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Lamp)) lampCnt++;
            Debug.Log($"Wall is not satisfied at ({posX},{posY})");
            return lampCnt == (int) puzzle.PuzzleMatrix[posX][posY];
        }
    }
}