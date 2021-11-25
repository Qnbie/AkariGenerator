using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.TestData;

namespace Tests.PlayModeTest.Algorithm.PuzzleSolver
{
    [TestFixture]
    public class PuzzleSolverSingleSolutionTest
    {
        private Algorithms.PuzzleSolver _puzzleSolver;

        [SetUp]
        public void StepUpTest()
        {
            _puzzleSolver = new Algorithms.PuzzleSolver();
        }

        [Test]
        public void EasyPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(TestPuzzleEasy.Puzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count == 1);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void NormalPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(TestPuzzleNormal.Puzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count == 1);
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void HardPuzzleSingleSolution()
        {
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(TestPuzzleHard.Puzzle);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Assert.True(solutions.Count == 1);
        }
    }
}