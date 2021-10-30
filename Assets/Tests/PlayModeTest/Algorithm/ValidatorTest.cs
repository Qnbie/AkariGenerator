using System.Collections.Generic;
using System.Threading;
using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;
using Utils.TestData;

namespace Tests
{
    [TestFixture]
    public class ValidatorTest
    {
        private Validator _validator;

        [SetUp]
        public void SetUpTest()
        {
            _validator = new Validator();
        }

        [Test]
        public void WallIsSatisfiedTest()
        {
            Puzzle puzzle = new Puzzle(PuzzleUtil.GetEmptyPuzzleMatrix(new Vector2Int(3,3)));

            puzzle.PuzzleMatrix[1][1] = TileStates.Four;
            puzzle.PuzzleMatrix[1][0] = TileStates.Lamp;
            puzzle.PuzzleMatrix[0][1] = TileStates.Lamp;
            puzzle.PuzzleMatrix[1][2] = TileStates.Lamp;
            puzzle.PuzzleMatrix[2][1] = TileStates.Lamp;
            
            Assert.True(_validator.WallIsSatisfied(1,1,puzzle));
            
            puzzle.PuzzleMatrix[1][0] = TileStates.Empty;
            puzzle.PuzzleMatrix[0][1] = TileStates.Empty;
            
            Assert.False(_validator.WallIsSatisfied(1,1,puzzle));
        }

        [Test, Timeout(10000)]
        public void PuzzleIsSolvedTest()
        {
            
            Assert.True(_validator.PuzzleIsSolved(TestPuzzleEasy.Puzzle,TestPuzzleEasy.Solution));
        }
    }
}