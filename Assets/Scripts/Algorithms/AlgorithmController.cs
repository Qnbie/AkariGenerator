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
        private FirebaseController _firebaseController;
        private Generator _generator;
        private PuzzleSolver _puzzleSolver;
        private LevelCalculator _levelCalculator;
        
        public AlgorithmController()
        {
            _validator = new Validator();
            _firebaseController = new FirebaseController();
            _generator = new Generator(_validator);
            _puzzleSolver = new PuzzleSolver(_validator);
            _levelCalculator = new LevelCalculator();
        }

        public Puzzle GetPuzzle(Difficulty difficulty)
        {
            List<RawPuzzle> puzzles = _firebaseController.GetPuzzle(difficulty);
            if (puzzles.Count != 0)
            {
                _firebaseController.RemovePuzzle(puzzles[0].Key);
                return PuzzleUtil.ConvertRawPuzzleToPuzzle(puzzles[0]);
            }

            Puzzle puzzle = new Puzzle();

            for (int i = 0; i < 5; i++)
            {
                puzzle = _generator.GeneratePuzzle(MapperUtil.DifficultyToSize[difficulty], difficulty);
                int solutionsCnt = _puzzleSolver.FindSolutions(puzzle);
                Difficulty levelOfDifficulty = _levelCalculator.CalculateDifficultly(puzzle, solutionsCnt);
                if (levelOfDifficulty == difficulty)
                {
                    return puzzle;
                }
                _firebaseController.AddPuzzle(PuzzleUtil.ConvertPuzzleToRawPuzzle(puzzle));
            }

            return puzzle;
        }
    }
}