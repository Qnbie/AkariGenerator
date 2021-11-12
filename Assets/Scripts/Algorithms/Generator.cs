using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Algorithms
{
    public class Generator
    {
        private List<Vector2Int> _walls;
        private List<Vector2Int> _lamps;
        private List<Vector2Int> _candidates;
        private Solution _solution;

        public Puzzle GeneratePuzzle(
            Vector2Int size)
        {
            var puzzle = new Puzzle(size);
            UpdateCandidates(puzzle);
            int baseCandidateNumber = _candidates.Count;
            do
            {
                for (int i = 0; i < 3; i++)
                {
                    PickCandidates(puzzle);
                }
            } while (_candidates.Count > 3/4 * baseCandidateNumber);
            
            return puzzle;
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
            if (_candidates.Count == 0)
            {
                return;
            }
            Vector2Int target = _candidates[Random.Range(0, _candidates.Count-1)];
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                puzzle.PuzzleMatrix[target.x][target.y] = TileStates.Wall;
            } 
            _candidates.Remove(target);
        }
    }
}