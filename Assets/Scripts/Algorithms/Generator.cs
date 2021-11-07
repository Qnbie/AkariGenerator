using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class Generator
    {
        private Validator _validator;
        private List<Vector2Int> _walls;
        private List<Vector2Int> _lamps;
        private List<Vector2Int> _candidates;
        private Solution _solution;

        public Generator(Validator validator)
        {
            _validator = validator;
        }

        public Puzzle GeneratePuzzle(
            Vector2Int size, 
            Difficulty difficulty)
        {
            _walls = new List<Vector2Int>();
            _lamps = new List<Vector2Int>();
            _solution = new Solution();
            Puzzle puzzle = new Puzzle(size);
            UpdateCandidates(puzzle);
            do
            {
                for (int i = 0; i < 5; i++)
                    PickCandidates(puzzle);
            } while (!_validator.PuzzleIsSolved(Corrector(puzzle), _solution));
            
            return ApplyNumbersOnWalls(puzzle);
        }

        private void UpdateCandidates(Puzzle puzzle)
        {
            _candidates = new List<Vector2Int>();
            for (int x = 0; x < puzzle.SizeX(); x++)
                for (int y = 0; y < puzzle.SizeY(); y++)
                    if (puzzle.PuzzleMatrix[x][y] == TileStates.Empty)
                        _candidates.Add(new Vector2Int(x, y));
        }

        private void PickCandidates(Puzzle puzzle)
        {
            Vector2Int target = _candidates[Random.Range(0, _candidates.Count-1)];
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                _lamps.Add(target);
            else
                puzzle.PuzzleMatrix[target.x][target.y] = TileStates.Wall;
            _candidates.Remove(target);
        }

        private Puzzle Corrector(Puzzle puzzle)
        {
            while (0 != _lamps.Count)
            {
                _solution.Positions.Add(_lamps[0]);
                if (!_validator.LampsCheck(puzzle, _solution))
                {
                    _solution.Positions.Remove(_lamps[0]);
                    _candidates.Add(_lamps[0]);
                }
                _lamps.RemoveAt(0);
            }
            _lamps.Clear();
            return puzzle;
        }

        private Puzzle ApplyNumbersOnWalls(Puzzle puzzle)
        {
            // TODO implement difficulty
            foreach (Vector2Int wallPlace in _walls)
            {
                int lampCnt = 0;
                if (PuzzleUtil.PlaceIsEqual(puzzle,
                wallPlace.x + 1, wallPlace.y,
                TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(puzzle,
                wallPlace.x - 1, wallPlace.y,
                TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(puzzle,
                wallPlace.x, wallPlace.y + 1,
                TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(puzzle,
                wallPlace.x, wallPlace.y - 1,
                TileStates.Lamp))
                    lampCnt++;

                puzzle.PuzzleMatrix[wallPlace.x][wallPlace.y] = (TileStates) lampCnt;
            }
            
            Debug.Log($"Walls are numbered /n {puzzle}");
            return puzzle;
        }
    }
}