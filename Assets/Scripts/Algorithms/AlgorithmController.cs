using System.Collections.Generic;
using Enums;
using NUnit.Framework;
using UnityEngine;
using Utils.DataStructures;
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

        public List<List<TileStates>> GetPuzzle(Difficulty difficulty)
        {
            List<RawPuzzle> puzzles = _firebaseController.GetPuzzle(difficulty);
            if (puzzles.Count != 0)
            {
                _firebaseController.RemovePuzzle(puzzles[0].Key);
                return ConvertRawPuzzleToPuzzle(puzzles[0]);
            }

            List<List<TileStates>> puzzle = new List<List<TileStates>>();

            for (int i = 0; i < 5; i++)
            {
                puzzle = _generator.GeneratePuzzle(MapperUtil.DifficultyToSize[difficulty], difficulty);
                int solutionsCnt = _puzzleSolver.FindSolutions(puzzle);
                Difficulty levelOfDifficulty = _levelCalculator.CalculateDifficultly(puzzle, solutionsCnt);
                if (levelOfDifficulty == difficulty)
                {
                    return puzzle;
                }
                _firebaseController.AddPuzzle(ConvertPuzzleToRawPuzzle(puzzle, difficulty));
            }

            return puzzle;
        }

        private RawPuzzle ConvertPuzzleToRawPuzzle(List<List<TileStates>> puzzle, Difficulty difficulty)
        {
            RawPuzzle result = new RawPuzzle();
            result.Size = new Vector2Int(puzzle.Count,puzzle[0].Count);
            result.Difficulty = (double)difficulty;
            for (int x = 0; x < puzzle.Count; x++)
            {
                for (int y = 0; y < puzzle[0].Count; y++)
                {
                    if(puzzle[x][y] != TileStates.Empty)
                        result.Elements.Add(new Element(new Vector2Int(x,y), puzzle[x][y]));
                }
            }
            return result;
        }

        private List<List<TileStates>> ConvertRawPuzzleToPuzzle(RawPuzzle rawPuzzle)
        {
            List<List<TileStates>> result = PuzzleUtil.GetEmptyPuzzle(rawPuzzle.Size);
            foreach (Element element in rawPuzzle.Elements)
            {
                result[element.Position.x][element.Position.y] = element.ElementState;
            }
            return result;
        }
    }
}