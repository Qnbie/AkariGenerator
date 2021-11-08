using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class AlgorithmController
    {
        private Validator _validator;
        private Generator _generator;
        private PuzzleSolver _puzzleSolver;
        private WallNumberApplier _wallNumberApplier;
        
        public AlgorithmController()
        {
            _validator = new Validator();
            _generator = new Generator();
            _puzzleSolver = new PuzzleSolver(_validator);
            _wallNumberApplier = new WallNumberApplier(_puzzleSolver);
        }

        public Puzzle GetPuzzle(Vector2Int size, Difficulty difficulty)
        {
            Puzzle puzzle = _generator.GeneratePuzzle(size);
            List<Solution> solutions = _puzzleSolver.FindAllSolutionWithEmptyWalls(puzzle);
            return _wallNumberApplier.ApplyNumbersOnWalls(puzzle,solutions,difficulty);
        }
    }
}