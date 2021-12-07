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
        private List<Vector2Int> _wallList;
        private readonly PuzzleSolver _puzzleSolver;

        public WallNumberApplier(PuzzleSolver puzzleSolver)
        {
            _puzzleSolver = puzzleSolver;
            _solutionDictionary = new Dictionary<Vector2Int, int>();
        }

        public Puzzle ApplyNumbersOnWalls(Puzzle puzzle, List<Solution> solutions, Difficulty difficulty)
        {
            SetUpSolutionDictionary(solutions);
            _wallList = puzzle.GetElementPositions(TileStates.Wall);
            var maxWallCount = (int) (MapperUtil.MaxWallByDifficulty[difficulty] *
                                      puzzle.GetElementPositions(TileStates.Wall).Count);
            Vector2Int lastPlace = new Vector2Int();
            int wallCount = 0;
            foreach (var position in 
                from solution in _solutionDictionary
                orderby solution.Value
                select solution.Key)
            {
                IncrementWalls(puzzle, position);
                lastPlace = position;
                wallCount++;
                if(_puzzleSolver.FindSingleSolutionWithNumberedWalls(puzzle).Count == 0 ||
                wallCount == maxWallCount) break;
            }

            if (wallCount < maxWallCount)
            {
                DecrementWalls(puzzle, lastPlace);
                AddZeroes(puzzle, _puzzleSolver.FindSingleSolutionWithNumberedWalls(puzzle)[0],
                    maxWallCount - wallCount - 1);
            }
            
            return puzzle;
        }

        private void AddZeroes(Puzzle puzzle, Solution solution, int zeroMax)
        {
            var list = puzzle.GetElementPositions(TileStates.Wall);
            int zeroCount = 0;
            foreach (var wallPos in list)
            {
                if (solution.Positions.Contains(new Vector2Int(wallPos.x, wallPos.y)) ||
                    solution.Positions.Contains(new Vector2Int(wallPos.x, wallPos.y)) ||
                    solution.Positions.Contains(new Vector2Int(wallPos.x, wallPos.y)) ||
                    solution.Positions.Contains(new Vector2Int(wallPos.x, wallPos.y)))
                    continue;
                puzzle.PuzzleMatrix[wallPos.x][wallPos.y] = TileStates.Zero;
                zeroCount++;
                if (zeroCount == zeroMax)
                    break;
            }
        }

        private void IncrementWalls(Puzzle puzzle, Vector2Int pos)
        {
            IncrementWallIfPossible(puzzle, new Vector2Int(pos.x+1,pos.y));
            IncrementWallIfPossible(puzzle, new Vector2Int(pos.x-1,pos.y));
            IncrementWallIfPossible(puzzle, new Vector2Int(pos.x,pos.y+1));
            IncrementWallIfPossible(puzzle, new Vector2Int(pos.x,pos.y-1));
        }

        private void IncrementWallIfPossible(Puzzle puzzle, Vector2Int pos)
        {
            if (!_wallList.Contains(pos)) return;
            if (puzzle.PuzzleMatrix[pos.x][pos.y] < (TileStates) 4)
                puzzle.PuzzleMatrix[pos.x][pos.y] += 1;
            if (puzzle.PuzzleMatrix[pos.x][pos.y] == TileStates.Wall)
                puzzle.PuzzleMatrix[pos.x][pos.y] = TileStates.One;
        }

        private void DecrementWalls(Puzzle puzzle, Vector2Int pos)
        {
            DecrementWallIfPossible(puzzle, new Vector2Int(pos.x+1,pos.y));
            DecrementWallIfPossible(puzzle, new Vector2Int(pos.x-1,pos.y));
            DecrementWallIfPossible(puzzle, new Vector2Int(pos.x,pos.y+1));
            DecrementWallIfPossible(puzzle, new Vector2Int(pos.x,pos.y-1));
        }

        private void DecrementWallIfPossible(Puzzle puzzle, Vector2Int pos)
        {
            if (!_wallList.Contains(pos)) return;
            if (puzzle.PuzzleMatrix[pos.x][pos.y] == TileStates.One)
                puzzle.PuzzleMatrix[pos.x][pos.y] = TileStates.Wall;
            if ((int)puzzle.PuzzleMatrix[pos.x][pos.y] <= 4)
                puzzle.PuzzleMatrix[pos.x][pos.y] -= 1;
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