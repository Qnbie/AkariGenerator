using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class PuzzleSolver
    {
        private Validator _validator;
        private PreProcessor _preProcessor;

        private Puzzle _puzzle;
        private List<Solution> _finalSolutions;
        private List<Vector2Int> _walls;

        
        public PuzzleSolver(Validator validator)
        {
            _validator = validator;
            _preProcessor = new PreProcessor(validator);
        }

        public List<Solution> FindSolutions(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _finalSolutions = new List<Solution>();
            _walls = new List<Vector2Int>();
            for (int x = 0; x < _puzzle.SizeX(); x++)
                for (int y = 0; y < _puzzle.SizeY(); y++)
                    if ((int)_puzzle.PuzzleMatrix[x][y] < 5)
                        _walls.Add(new Vector2Int(x,y));
            var puzzleTmp = _preProcessor.Process(new Puzzle(_puzzle));

            BacktrackFunction( 
                puzzleTmp.GetElementPositions(TileStates.Empty),
                new Solution(puzzleTmp.GetElementPositions(TileStates.Lamp)));
            return _finalSolutions;
        }

        private void BacktrackFunction(
            List<Vector2Int> candidates,
            Solution solution)
        {
            
            if (_validator.PuzzleIsSolved(new Puzzle(_puzzle), solution))
            {
                var solutionTmp = new Solution(solution.Positions);
                _finalSolutions.Add(new Solution(solutionTmp));
                return;
            }

            if (candidates.Count == 0)
            {
                return;
            }

            if (WallsAreUnsatisfiable(new Puzzle(_puzzle), new Solution(solution)))
            {
                return;
            }
            
            Vector2Int nextCandidate = candidates[0];
            candidates.Remove(nextCandidate);
            solution.Positions.Add(nextCandidate);
            BacktrackFunction(new List<Vector2Int>(candidates), new Solution(solution));
            solution.Positions.Remove(nextCandidate);
            BacktrackFunction(candidates, solution);
        }
        
        private string CandidateLog(List<Vector2Int> candidates)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Candidates:");
            foreach (var candidate in candidates)
                stringBuilder.AppendLine($"x : {candidate.x} y : {candidate.y}");
            return stringBuilder.ToString();
        }
        
        private bool WallsAreUnsatisfiable(Puzzle puzzle, Solution solution)
        {
            Puzzle litPuzzle = PuzzleUtil.TurnOnLamps(puzzle, solution);
            foreach (var wall in _walls)
            {
                if (_validator.WallIsSatisfied(wall.x, wall.y, litPuzzle)) continue;
                if (CanBeSatisfied(wall.x, wall.y, litPuzzle)) continue;
                return true;
            }
            return false;
        }

        private bool CanBeSatisfied(int posX, int posY, Puzzle puzzle)
        {
            int emptyCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Empty)) emptyCnt++;
            return emptyCnt > 0;
        }

        public int NumberOfDifferentSolution(List<Solution> solutions)
        {
            int numberOfDifferentSolution = 0;
            for (int i = 0; i < solutions.Count-1; i++)
            {
                for (int j = i+1; j < solutions.Count; j++)
                {
                    if (Similiarity(solutions[i], solutions[j]) < StaticData.DifTarget)
                        numberOfDifferentSolution++;
                }
            }
            return numberOfDifferentSolution;
        }

        private int Similiarity(Solution solutionA, Solution solutionB)
        {
            int num = Math.Abs(solutionA.Count - solutionB.Count);
            foreach (var solution in solutionA.Positions)
            {
                if (!solutionB.Positions.Contains(solution))
                    num++;
            }
            return num;
        }
    }
}