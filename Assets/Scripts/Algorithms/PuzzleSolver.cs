using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Vector2Int> _implacable;

        
        public PuzzleSolver(Validator validator)
        {
            _validator = validator;
            _preProcessor = new PreProcessor(validator);
        }

        public List<Solution> FindAllSolutionWithEmptyWalls(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _finalSolutions = new List<Solution>();
            _implacable = new List<Vector2Int>();
            BacktrackFunction(
                new Solution(),
                singleSolution: false,
                numberedWall: false);
            return _finalSolutions;
        }
        
        public List<Solution> FindSingleSolutionWithNumberedWalls(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _finalSolutions = new List<Solution>();
            _walls = new List<Vector2Int>();
            _implacable = new List<Vector2Int>();
            for (int x = 0; x < _puzzle.SizeX(); x++)
            for (int y = 0; y < _puzzle.SizeY(); y++)
                if ((int)_puzzle.PuzzleMatrix[x][y] < 5)
                    _walls.Add(new Vector2Int(x,y));
            var preProcessedPuzzle = _preProcessor.Process(new Puzzle(_puzzle));
            _implacable = preProcessedPuzzle.GetElementPositions(TileStates.Implacable);
            BacktrackFunction(
                new Solution(preProcessedPuzzle.GetElementPositions(TileStates.Lamp)),
                singleSolution: true, 
                numberedWall: true);
            return _finalSolutions;
        }

        private void BacktrackFunction(
            Solution solution, 
            bool singleSolution,
            bool numberedWall)
        {
            Debug.Log("run start");
            if (singleSolution && _finalSolutions.Count > 0)
            {
                return;
            }
            if (_validator.PuzzleIsSolved(new Puzzle(_puzzle), new Solution(solution)))
            {
                Debug.Log($"Add ok Solution \n {solution}");
                _finalSolutions.Add(new Solution(solution));
                return;
            }

            List<Vector2Int> candidates = CalculateCandidates(solution);

            Debug.Log($"Solutions \n {solution}");
            Debug.Log($"Candidates \n {CandidateLog(candidates)}");
            Debug.Log($"Implacables \n {CandidateLog(_implacable)}");
            
            
            if (candidates.Count == 0)
            {
                return;
            }

            if (numberedWall && WallsAreUnsatisfiable(new Puzzle(_puzzle), new Solution(solution)))
            {
                return;
            }
            
            Vector2Int nextCandidate = candidates[0];
            _implacable.Add(candidates[0]);
            solution.Positions.Add(nextCandidate);
            BacktrackFunction(
                solution,
                singleSolution, numberedWall);
            
            solution.Positions.Remove(nextCandidate);
            BacktrackFunction(
                solution,
                singleSolution, numberedWall);
            _implacable.Remove(candidates[0]);
            Debug.Log("run end");
        }

        private List<Vector2Int> CalculateCandidates(Solution solution)
        {
            var candidates = new List<Vector2Int>();
            _puzzle.TurnOnLamps(solution);
            candidates = _puzzle.GetElementPositions(TileStates.Empty).Except(_implacable).ToList();
            _puzzle.TurnOfLamps();
            return candidates;
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
            puzzle.TurnOnLamps(solution);
            foreach (var wall in _walls)
            {
                if (_validator.WallIsSatisfied(wall.x, wall.y, puzzle)) continue;
                if (CanBeSatisfied(wall.x, wall.y, puzzle)) continue;
                puzzle.TurnOfLamps();
                return true;
            }
            puzzle.TurnOfLamps();
            return false;
        }

        private bool CanBeSatisfied(int posX, int posY, Puzzle puzzle)
        {
            int emptyCnt = 0;
            if (puzzle.PlaceIsEqual(posX + 1, posY, TileStates.Empty)) emptyCnt++;
            if (puzzle.PlaceIsEqual(posX - 1, posY, TileStates.Empty)) emptyCnt++;
            if (puzzle.PlaceIsEqual(posX, posY + 1, TileStates.Empty)) emptyCnt++;
            if (puzzle.PlaceIsEqual(posX, posY - 1, TileStates.Empty)) emptyCnt++;
            return emptyCnt > 0;
        }
    }
}