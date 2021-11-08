using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.TestData;

namespace Tests.PlayModeTest.Algorithm.PuzzleSolver
{
    [TestFixture]
    public class PuzzleSolverAllSolutionTest
    {
        private Algorithms.PuzzleSolver _puzzleSolver;

        [SetUp]
        public void StepUpTest()
        {
            _puzzleSolver = new Algorithms.PuzzleSolver(new Validator());
        }

        [Test]
        public void EasyPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindAllSolutionWithEmptyWalls(TestPuzzleEasy.PlainPuzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count > 0);
        }
        
        [Test]
        public void NormalPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindAllSolutionWithEmptyWalls(TestPuzzleNormal.PlainPuzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count > 0);
        }
        
        [Test]
        public void HardPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(TestPuzzleHard.PlainPuzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count > 0);
        }
    }
}