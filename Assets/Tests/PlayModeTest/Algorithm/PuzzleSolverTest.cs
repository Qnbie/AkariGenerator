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
            var solutions = _puzzleSolver.FindSolutions(TestPuzzles.GoodPuzzle);
            
            Assert.True(solutions.Contains(TestPuzzles.GoodSolution));
            Debug.Log("Test is passed");
        }
    }
}