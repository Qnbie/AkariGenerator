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
            Puzzle puzzle = new Puzzle(size);
            UpdateCandidates(puzzle);
            do
            {
                for (int i = 0; i < 5; i++)
                    PickCandidates();
            } while (!_validator.PuzzleIsSolved(
                        Corrector(puzzle), 
                        new Solution(_lamps)));
            
            return ApplyNumbersOnWalls(puzzle);;
        }

        private void UpdateCandidates(Puzzle puzzle)
        {
            _candidates = new List<Vector2Int>();
            for (int x = 0; x < puzzle.SizeX(); x++)
                for (int y = 0; y < puzzle.SizeY(); y++)
                    if (puzzle.PuzzleMatrix[x][y] == TileStates.Empty)
                        _candidates.Add(new Vector2Int(x, y));
        }

        private void PickCandidates()
        {
            Vector2Int target = _candidates[Random.Range(0, _candidates.Count)];
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                _lamps.Add(target);
            else
                _walls.Add(target);
        }

        private Puzzle Corrector(Puzzle puzzle)
        {
            foreach (Vector2Int wall in _walls)
            {
                _candidates.Remove(wall);
                puzzle.PuzzleMatrix[wall.x][wall.y] = TileStates.Wall;
            }
            _walls.Clear();

            foreach (var lamp in _lamps)
            {
                _solution.Positions.Add(lamp);
                if (!_validator.LampsCheck(puzzle, _solution))
                {
                    _solution.Positions.Remove(lamp);
                    _candidates.Add(lamp);
                }
            }
            _lamps.Clear();
            UpdateCandidates(PuzzleUtil.TurnOnLamps(puzzle,_solution));
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