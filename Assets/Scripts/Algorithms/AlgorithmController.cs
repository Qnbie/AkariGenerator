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
        
        public AlgorithmController()
        {
            _validator = new Validator();
            _generator = new Generator(_validator);
            _puzzleSolver = new PuzzleSolver(_validator);
        }

        public Puzzle GetPuzzle(Vector2Int size, Difficulty difficulty)
        {
            Puzzle puzzle = new Puzzle(size);
            return puzzle;
        }
    }
}