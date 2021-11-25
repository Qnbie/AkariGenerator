using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Random = UnityEngine.Random;

namespace Algorithms
{
    public class PuzzleSolver
    {
        private readonly Validator _validator;
        private readonly PreProcessor _preProcessor;

        private Puzzle _puzzle;
        private List<Solution> _finalSolutions;
        private List<Vector2Int> _walls;
        private List<Vector2Int> _implacable;

        
        public PuzzleSolver()
        {
            _validator = new Validator();
            _preProcessor = new PreProcessor(_validator);
        }

        public List<Solution> FindSolutionsWithEmptyWalls(Puzzle puzzle, int numberOfSolution)
        {
            _puzzle = puzzle;
            _finalSolutions = new List<Solution>();
            _implacable = new List<Vector2Int>();
            for (int i = 0; i < numberOfSolution; i++)
            {
                BacktrackFunction(
                    new Solution(),
                     false);
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
                numberedWall: true);
            return _finalSolutions;
        }

        private bool BacktrackFunction(
            Solution solution, 
            bool numberedWall)
        {
            if (_validator.PuzzleIsSolved(new Puzzle(_puzzle), new Solution(solution)))
            {
                _finalSolutions.Add(new Solution(solution));
                return true;
            }

            var candidates = CalculateCandidates(solution);
            if (candidates.Count == 0)
            {
                return false;
            }

            if (numberedWall && WallsAreUnsatisfiable(new Puzzle(_puzzle), new Solution(solution)))
            {
                return false;
            }
            
            var nextCandidate = candidates[Random.Range(0, candidates.Count-1)];
            _implacable.Add(nextCandidate);
            solution.Positions.Add(nextCandidate);
            var solutionFound = BacktrackFunction(
                solution,
                numberedWall);
            if (solutionFound)
                return true;
            solution.Positions.Remove(nextCandidate);
            solutionFound = BacktrackFunction(
                solution,
                numberedWall);
            _implacable.Remove(nextCandidate);
            return solutionFound;
        }

        private List<Vector2Int> CalculateCandidates(Solution solution)
        {
            _puzzle.TurnOnLamps(solution);
            var candidates = _puzzle.GetElementPositions(TileStates.Empty).Except(_implacable).ToList();
            _puzzle.TurnOfLamps();
            return candidates;
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