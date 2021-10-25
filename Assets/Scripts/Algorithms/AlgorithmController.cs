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
            Debug.Log("GetPuzzle is starting");
            
            Debug.Log($"Check database for puzzle with {difficulty} difficulty");
            List<RawPuzzle> puzzles = _firebaseController.GetPuzzle(difficulty);
            if (puzzles.Count != 0)
            {
                Debug.Log($"Find a puzzle in database \n {puzzles[0]}");
                _firebaseController.RemovePuzzle(puzzles[0].Key);
                return PuzzleUtil.ConvertRawPuzzleToPuzzle(puzzles[0]);
            }

            Debug.Log($"There is no puzzle in the database with {difficulty} " +
                      $"difficulty \n Start puzzle generation");
            
            Puzzle puzzle = new Puzzle();
            for (int i = 0; i < 5; i++)
            {
                Debug.Log($"Puzzle generation iteration number {i}");
                puzzle = _generator.GeneratePuzzle(MapperUtil.DifficultyToSize[difficulty], difficulty);
                int solutionsCnt = _puzzleSolver.NumberOfDifferentSolution(_puzzleSolver.FindSolutions(puzzle));
                Debug.Log($"Solution count: {solutionsCnt}");
                Difficulty levelOfDifficulty = _levelCalculator.CalculateDifficultly(puzzle, solutionsCnt);
                Debug.Log($"Difficulty level: {levelOfDifficulty}");
                if (levelOfDifficulty == difficulty)
                {
                    Debug.Log($"Difficulty is matched\n {puzzle}\n GetPuzzle is done");
                    return puzzle;
                }
                Debug.Log("Difficulty is not matched");
                _firebaseController.AddPuzzle(PuzzleUtil.ConvertPuzzleToRawPuzzle(puzzle));
            }

            Debug.Log($"Difficulty is not found\n {puzzle}\n GetPuzzle is done");
            return puzzle;
        }
    }
}