using Algorithms;
using NUnit.Framework;

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
            // Todo 
        }
    }
}