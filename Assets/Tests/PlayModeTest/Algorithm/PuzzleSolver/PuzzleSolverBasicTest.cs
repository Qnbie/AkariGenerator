using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Tests.PlayModeTest.Algorithm.PuzzleSolver 
{
    [TestFixture]
    public class PuzzleSolverBasicTest
    {
        private Algorithms.PuzzleSolver _puzzleSolver;

        [SetUp]
        public void StepUpTest()
        {
            _puzzleSolver = new Algorithms.PuzzleSolver();
        }

        [Test] public void EmptyPuzzle()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            var solutions = _puzzleSolver.FindSolutionsWithEmptyWalls(tmpPuzzle, 5);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 5);
        }
        
        [Test]
        public void MiddleWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Wall;
            var solutions = _puzzleSolver.FindSolutionsWithEmptyWalls(tmpPuzzle, 5);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 5);
        }
     
        [Test]
        public void MiddleFourWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Four;
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 1);
        }     
        [Test]
        public void MiddleThreeWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Three;
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(tmpPuzzle);            
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 0);
        }

             
        [Test]
        public void MiddleTwoWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Two;
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 1);
        }
             
        [Test]
        public void MiddleOneWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.One;
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 0);
        }
        
        [Test]
        public void MiddleZeroWall()
        {
            var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Zero;
            var solutions = _puzzleSolver.FindSingleSolutionWithNumberedWalls(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            Assert.True(solutions.Count == 1);
        }
    }
}