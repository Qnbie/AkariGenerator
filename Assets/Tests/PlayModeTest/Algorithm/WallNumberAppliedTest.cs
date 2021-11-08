using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.Enums;


namespace Tests.PlayModeTest.Algorithm
{
    [TestFixture]
    public class WallNumberAppliedTest
    {
        private WallNumberApplier _wallNumberApplier;
        private Generator _generator;
        private Algorithms.PuzzleSolver _puzzleSolver;
        
        [SetUp]
        public void SetUpTest()
        {
            Validator validator = new Validator();
            _generator = new Generator();
            _puzzleSolver = new Algorithms.PuzzleSolver(validator);
            _wallNumberApplier = new WallNumberApplier(_puzzleSolver);
        }

        [Test]
        public void LittlePuzzleEasy()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(5, 5));
            var solution = _puzzleSolver.FindAllSolutionWithEmptyWalls(puzzle);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Easy);
        }
    }
}