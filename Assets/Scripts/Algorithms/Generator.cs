using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class Generator
    {
        private List<Vector2Int> _candidates;
        private List<Vector2Int> _lamps;
        private List<Vector2Int> _walls;
        private Validator _validator;
        private Puzzle _puzzle;

        public Generator(Validator validator)
        {
            _validator = validator;
        }

        public Puzzle GeneratePuzzle(
            Vector2Int size, 
            Difficulty difficulty)
        {
            SetUpCandidates(size);
            do
            {
                for (int i = 0; i < 5; i++)
                {
                    PutElement();
                }

                Corrector();
            } while (!_validator.PuzzleIsSolved(PuzzleWithWalls(), _lamps));
            ApplyNumbersOnWalls();
            return _puzzle;
        }

        private Puzzle PuzzleWithWalls()
        {
            foreach (Vector2Int wallPos in _walls)
            {
                _puzzle.PuzzleMatrix[wallPos.x][wallPos.y] = TileStates.Lamp;
            }

            return _puzzle;
        }

        private void SetUpCandidates(Vector2 size)
        {
            for (int x = 0; x < size.x; x++)
            {
                _puzzle.PuzzleMatrix.Add(new List<TileStates>());
                for (int y = 0; y < size.y; y++)
                {
                    _candidates.Add(new Vector2Int(x, y));
                    _puzzle.PuzzleMatrix[x].Add(TileStates.Empty);
                }
            }
        }
        
        private void PutElement()
        {
            Vector2Int target = _candidates[Random.Range(0, _candidates.Count)];
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                _lamps.Add(target);
            }
            else
            {
                _walls.Add(target);
            }

            _candidates.Remove(target);
        }

        private void Corrector()
        {
            foreach (Vector2Int wallPlace in _walls)
            {
                // TODO
            }
        }

        private void ApplyNumbersOnWalls()
        {
            // TODO implement difficulty
            foreach (Vector2Int wallPlace in _walls)
            {
                int lampCnt = 0;
                if (PuzzleUtil.PlaceIsEqual(_puzzle,wallPlace.x + 1, wallPlace.y,TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(_puzzle,wallPlace.x - 1, wallPlace.y, TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(_puzzle,wallPlace.x, wallPlace.y + 1, TileStates.Lamp))
                    lampCnt++;
                if (PuzzleUtil.PlaceIsEqual(_puzzle,wallPlace.x, wallPlace.y - 1, TileStates.Lamp))
                    lampCnt++;
                _puzzle.PuzzleMatrix[wallPlace.x][wallPlace.y] = (TileStates) lampCnt;
            }
        }
    }
}