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
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle,5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Easy);
        }
        
        [Test]
        public void LittlePuzzleNormal()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(5, 5));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle,5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Medium);
        }
        
        [Test]
        public void LittlePuzzleHard()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(5, 5));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle,5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Hard);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void NormalPuzzleEasy()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(7,7));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle,5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Easy);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void NormalPuzzleNormal()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(7,7));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle,5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Medium);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void NormalPuzzleHard()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(7,7));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle, 5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Hard);
        }
                
        [Test]
        [Ignore("Not implemented")]
        public void BigPuzzleEasy()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(10,10));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle, 5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Easy);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void BigPuzzleNormal()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(10,10));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle, 5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Medium);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void BigPuzzleHard()
        {
            var puzzle = _generator.GeneratePuzzle(new Vector2Int(10,10));
            var solution = _puzzleSolver.FindSolutionsWithEmptyWalls(puzzle, 5);
            _wallNumberApplier.ApplyNumbersOnWalls(puzzle, solution, Difficulty.Hard);
        }
    }
}