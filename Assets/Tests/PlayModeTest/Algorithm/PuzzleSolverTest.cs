using Algorithms;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using Utils.TestData;

namespace Tests
{
    [TestFixture]
    public class PuzzleSolverTest
    {
        private PuzzleSolver _puzzleSolver;

        [SetUp]
        public void StepUpTest()
        {
            _puzzleSolver = new PuzzleSolver(new Validator());
        }

        [Test]
        public void NumberOfDifferentSolutionTest()
        {
            // Todo 
        }

        [Test]
        public void FindSolutionsTest()
        {
            // One known solution
            var solutions = _puzzleSolver.FindSolutions(TestPuzzleEasy.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleEasy.Solution));
            Debug.Log("Easy Puzzle with one known solution is passed");
            solutions = _puzzleSolver.FindSolutions(TestPuzzleNormal.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleNormal.Solution));
            Debug.Log("Normal Puzzle with one known solution is passed");
            solutions = _puzzleSolver.FindSolutions(TestPuzzleHard.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleHard.Solution));
            Debug.Log("Hard Puzzle with one known solution is passed");
            
            // Multiply known solution
            // TODO
            
            // No solution
            solutions = _puzzleSolver.FindSolutions(TestPuzzleNoSolution.EasyPuzzle);
            Assert.True(solutions.Count == 0);
            Debug.Log("Easy Puzzle with no solution is passed");
            solutions = _puzzleSolver.FindSolutions(TestPuzzleNoSolution.NormalPuzzle);
            Assert.True(solutions.Count == 0);
            Debug.Log("Normal Puzzle with no solution is passed");
            solutions = _puzzleSolver.FindSolutions(TestPuzzleNoSolution.HardPuzzle);
            Assert.True(solutions.Count == 0);
            Debug.Log("Hard Puzzle with no solution is passed");

        }
    }
}