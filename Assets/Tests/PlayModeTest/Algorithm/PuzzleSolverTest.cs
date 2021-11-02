using System.Collections.Generic;
using Algorithms;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
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
        public void BaseSolverTest()
        {

            var tmpPuzzle = new Puzzle(new Vector2Int(3,3));
            var solutions = _puzzleSolver.FindSolutions(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);

            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Wall;
            solutions = _puzzleSolver.FindSolutions(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Four;
            solutions = _puzzleSolver.FindSolutions(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Three;
            solutions = _puzzleSolver.FindSolutions(tmpPuzzle);            
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.Two;
            solutions = _puzzleSolver.FindSolutions(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
            
            tmpPuzzle.PuzzleMatrix[1][1] = TileStates.One;
            solutions = _puzzleSolver.FindSolutions(tmpPuzzle);
            Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
                Debug.Log(solution);
        }
        
        [Test]
        public void FindSolutionsTestEasy()
        {
            // One known solution
            var solutions = _puzzleSolver.FindSolutions(TestPuzzleEasy.Puzzle);
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Debug.Log(TestPuzzleEasy.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleEasy.Solution));
            Debug.Log("Easy Puzzle with one known solution is passed");
        }
        
        [Test, Timeout(10000)]
        public void FindSolutionsTestNormal()
        {
            // One known solution
            var solutions = _puzzleSolver.FindSolutions(TestPuzzleNormal.Puzzle);
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Debug.Log(TestPuzzleNormal.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleNormal.Solution));
            Debug.Log("Normal Puzzle with one known solution is passed");
        }
        
        [Test, Timeout(10000)]
        public void FindSolutionsTestHard()
        {
            // One known solution
            var solutions = _puzzleSolver.FindSolutions(TestPuzzleHard.Puzzle);
            Debug.Log(solutions.Count);
            foreach (var solution in solutions)
            {
                Debug.Log(solution);
            }
            Debug.Log(TestPuzzleHard.Puzzle);
            Assert.True(solutions.Contains(TestPuzzleHard.Solution));
            Debug.Log("Hard Puzzle with one known solution is passed");
        }
    }
}