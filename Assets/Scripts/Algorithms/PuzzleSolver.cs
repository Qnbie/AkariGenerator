using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;
using Random = UnityEngine.Random;

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
            for (int i = 0; i < 5; i++)
            {
                BacktrackFunction(
                    new Solution(),
                    solutionFound: false,
                    numberedWall: false);
            }
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
                solutionFound: false, 
                numberedWall: true);
            return _finalSolutions;
        }

        private bool BacktrackFunction(
            Solution solution, 
            bool solutionFound,
            bool numberedWall)
        {
            Debug.Log("run start");
            if (solutionFound)
            {
                return true;
            }
            if (_validator.PuzzleIsSolved(new Puzzle(_puzzle), new Solution(solution)))
            {
                Debug.Log($"Add ok Solution \n {solution}");
                _finalSolutions.Add(new Solution(solution));
                solutionFound = true;
                return true;
            }

            List<Vector2Int> candidates = CalculateCandidates(solution);

            Debug.Log($"Solutions \n {solution}");
            Debug.Log($"Candidates \n {CandidateLog(candidates)}");
            Debug.Log($"Implacables \n {CandidateLog(_implacable)}");
            
            
            if (candidates.Count == 0)
            {
                return false;
            }

            if (numberedWall && WallsAreUnsatisfiable(new Puzzle(_puzzle), new Solution(solution)))
            {
                return false;
            }
            
            Vector2Int nextCandidate = candidates[Random.Range(0, candidates.Count-1)];
            _implacable.Add(nextCandidate);
            solution.Positions.Add(nextCandidate);
            solutionFound = BacktrackFunction(
                solution,
                solutionFound,
                numberedWall);
            
            solution.Positions.Remove(nextCandidate);
            solutionFound = BacktrackFunction(
                solution,
                solutionFound,
                numberedWall);
            _implacable.Remove(nextCandidate);
            Debug.Log("run end");
            return solutionFound;
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