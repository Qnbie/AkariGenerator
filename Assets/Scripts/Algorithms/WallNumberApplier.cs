using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.Helpers;

namespace Algorithms
{
    public class WallNumberApplier
    {
        private readonly Dictionary<Vector2Int, int> _solutionDictionary;
        private readonly Dictionary<Vector2Int, int> _wallDictionary;
        private readonly PuzzleSolver _puzzleSolver;

        public WallNumberApplier(PuzzleSolver puzzleSolver)
        {
            _puzzleSolver = puzzleSolver;
            _solutionDictionary = new Dictionary<Vector2Int, int>();
            _wallDictionary = new Dictionary<Vector2Int, int>();
        }

        public Puzzle ApplyNumbersOnWalls(Puzzle puzzle, List<Solution> solutions, Difficulty difficulty)
        {
            SetUpSolutionDictionary(solutions);
            SetUpWallDictionary(puzzle);
            var topSolutions =
                (from solution in _solutionDictionary
                orderby solution.Value
                select solution.Key).ToArray();

            foreach (var solution in topSolutions)
            {
                IncrementWalls(solution);
            }

            var finalSolution = new List<Solution>();
            var wallCount = 0;
            var maxWallCount = (int) (MapperUtil.MaxWallByDifficulty[difficulty] * _wallDictionary.Count);
            foreach (var wallElement in 
                _wallDictionary.Where(wallElement => wallElement.Value > 0))
            {
                puzzle.PuzzleMatrix[wallElement.Key.x][wallElement.Key.y] = (TileStates) wallElement.Value;
                finalSolution.AddRange(_puzzleSolver.FindSingleSolutionWithNumberedWalls(puzzle));
                if (finalSolution.Count == wallCount)
                {
                    puzzle.PuzzleMatrix[wallElement.Key.x][wallElement.Key.y] = TileStates.Wall;
                }
                else
                {
                    wallCount++;
                    if (wallCount == maxWallCount)
                    {
                        break;
                    }
                }
            }

            puzzle.TurnOnLamps(finalSolution.Last());
            for (var i = wallCount; i < maxWallCount; i++)
            {
                foreach (var wallPos in puzzle.GetElementPositions(TileStates.Wall))
                {
                    if (!CanBeZero(wallPos, puzzle)) continue;
                    puzzle.PuzzleMatrix[wallPos.x][wallPos.y] = TileStates.Zero;
                    break;
                }
                
            }
            puzzle.TurnOfLamps();
            puzzle.DifficultyLevel = difficulty;
            return puzzle;
        }

        private bool CanBeZero(Vector2Int wallPos, Puzzle puzzle)
        {
            return !(puzzle.PlaceIsEqual(wallPos.x + 1, wallPos.y, TileStates.Lamp) ||
                     puzzle.PlaceIsEqual(wallPos.x - 1, wallPos.y, TileStates.Lamp) ||
                     puzzle.PlaceIsEqual(wallPos.x, wallPos.y + 1, TileStates.Lamp) ||
                     puzzle.PlaceIsEqual(wallPos.x, wallPos.y - 1, TileStates.Lamp));
        }
        
        private void IncrementWalls(Vector2Int topSolution)
        {
            IncrementWallIfPossible(new Vector2Int(topSolution.x + 1, topSolution.y));
            IncrementWallIfPossible(new Vector2Int(topSolution.x - 1, topSolution.y));
            IncrementWallIfPossible(new Vector2Int(topSolution.x, topSolution.y + 1));
            IncrementWallIfPossible(new Vector2Int(topSolution.x, topSolution.y - 1));
        }

        private void IncrementWallIfPossible(Vector2Int position)
        {
            if (_wallDictionary.ContainsKey(position))
            {
                _wallDictionary[position]++;
            }
        }

        private void SetUpWallDictionary(Puzzle puzzle)
        {
            _wallDictionary.Clear();
            foreach (var wallPos in puzzle.GetElementPositions(TileStates.Wall))
            {
                _wallDictionary.Add(wallPos,0);
            }
        }

        private void SetUpSolutionDictionary(List<Solution> solutions)
        {
            _solutionDictionary.Clear();
            foreach (var solution in solutions)
            {
                foreach (var position in solution.Positions)
                {
                    if (_solutionDictionary.ContainsKey(position))
                    {
                        _solutionDictionary[position]++;
                    }
                    else
                    {
                        _solutionDictionary.Add(position, 1);
                    }
                }
            }
        }
    }
}