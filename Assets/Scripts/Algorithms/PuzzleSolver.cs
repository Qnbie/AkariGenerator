using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class PuzzleSolver
    {
        private Validator _validator;

        public PuzzleSolver(Validator validator)
        {
            _validator = validator;
        }

        public List<List<Vector2Int>> FindSolutions(Puzzle puzzle)
        {
            List<Vector2Int> solutionCandidates = new List<Vector2Int>();
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if (puzzle.PuzzleMatrix[x][y] == TileStates.Empty)
                    {
                        solutionCandidates.Add(new Vector2Int(x,y));
                    }
                }
            }
            
            return BacktrackFunction(puzzle, solutionCandidates, new List<Vector2Int>() ,new List<List<Vector2Int>>());
        }

        private List<List<Vector2Int>> BacktrackFunction(
            Puzzle puzzle,
            List<Vector2Int> candidates,
            List<Vector2Int> solution, 
            List<List<Vector2Int>> finalSolutions)
        {
            if (_validator.PuzzleIsSolved(puzzle, solution))
            {
                finalSolutions.Add(solution);
                return finalSolutions;
            }
            if (candidates.Count == 0 || WallsAreUnsatisfiable(puzzle, solution)) return finalSolutions;
            Vector2Int nextCandidate = candidates[0];
            solution.Add(nextCandidate);
            BacktrackFunction(puzzle, candidates, solution, finalSolutions);
            candidates.Remove(nextCandidate);
            solution.Remove(nextCandidate);
            BacktrackFunction(puzzle, candidates, solution, finalSolutions);
            return finalSolutions;
        }

        private bool WallsAreUnsatisfiable(Puzzle puzzle, List<Vector2Int> solution)
        {
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if ((int)puzzle.PuzzleMatrix[x][y] < 5)
                    {
                        if (!_validator.WallIsSatisfied(x, y, puzzle))
                            if (NoMoreSpace(x, y, puzzle))
                                return true;
                    }
                }
            }
            return false;
        }

        private bool NoMoreSpace(int posX, int posY, Puzzle puzzle)
        {
            int emptyCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Empty)) emptyCnt++;
            return emptyCnt == 0;
        }

        public int NumberOfDifferentSolution(List<List<Vector2Int>> solutions)
        {
            // TODO implement complex solution counter methode
            return solutions.Count;
        }
    }
}