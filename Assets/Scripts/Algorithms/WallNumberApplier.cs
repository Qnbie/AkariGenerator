using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class WallNumberApplier
    {
        private Dictionary<Vector2Int, int> _solutionDictionary;
        private Dictionary<Vector2Int, int> _wallDictionary;
        private PuzzleSolver _puzzleSolver;

        public WallNumberApplier(Validator validator, PuzzleSolver puzzleSolver)
        {
            _puzzleSolver = puzzleSolver;
            _solutionDictionary = new Dictionary<Vector2Int, int>();
            _wallDictionary = new Dictionary<Vector2Int, int>();
        }

        public void ApplyNumbersOnWalls(List<Solution> solutions, Puzzle puzzle, Difficulty difficulty)
        {
            SetUpSolutionDictionary(solutions);
            SetUpWallDictionary(puzzle);
            int solutionCount = _solutionDictionary.Count;
            Vector2Int[] topSolutions =
                (from solution in _solutionDictionary
                orderby solution.Value
                select solution.Key).Take((int) (solutionCount * MapperUtil.DifToWallNum(difficulty))).ToArray();
            int index = 0;

            foreach (var solution in topSolutions)
            {
                IncrementWalls(solution);
            }
            
            do
            {
                StartAddition(puzzle);
                foreach (var wallElement in 
                    _wallDictionary.Where(wallElement => wallElement.Value > 0))
                {
                    puzzle.PuzzleMatrix[wallElement.Key.x][wallElement.Key.y] = (TileStates) wallElement.Value;
                }
                _wallDictionary.Remove(_wallDictionary.Keys.Last());
            } while (_puzzleSolver.FindSolutions(puzzle).Count == 0);
        }

        private void StartAddition(Puzzle puzzle)
        {
            foreach (var wallElement in _wallDictionary)
            {
                puzzle.PuzzleMatrix[wallElement.Key.x][wallElement.Key.y] = TileStates.Wall;
            }
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
            foreach (Vector2Int wallPos in puzzle.GetElementPositions(TileStates.Wall))
            {
                _wallDictionary.Add(wallPos,0);
            }
        }

        private void SetUpSolutionDictionary(List<Solution> solutions)
        {
            foreach (Solution solution in solutions)
            {
                foreach (Vector2Int position in solution.Positions)
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