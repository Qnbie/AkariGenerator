using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Algorithms
{
    public class AlgorithmController
    {
        private readonly Generator _generator;
        private readonly PuzzleSolver _puzzleSolver;
        private readonly WallNumberApplier _wallNumberApplier;
        
        public AlgorithmController()
        {
            _generator = new Generator();
            _puzzleSolver = new PuzzleSolver();
            _wallNumberApplier = new WallNumberApplier(_puzzleSolver);
        }

        public Puzzle GetPuzzle(Vector2Int size, Difficulty difficulty)
        {
            var puzzle = _generator.GeneratePuzzle(size);
            var solutions = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle, 5);
            return _wallNumberApplier.ApplyNumbersOnWalls(puzzle,solutions,difficulty);
        }
    }
}