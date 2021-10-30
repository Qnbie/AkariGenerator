using NUnit.Framework;
using UnityEngine;
using Utils.Enums;
using Utils.StaticClasses;
using Utils.TestData;

namespace Tests.PlayModeTest
{
    [TestFixture]
    public class PuzzleUtilTest
    {
        [Test]
        public void IsInTheBoardTest()
        {
            Assert.True(PuzzleUtil.IsInTheBoard(0,0,3,3));
            Assert.True(PuzzleUtil.IsInTheBoard(1,1,3,3));
            Assert.True(PuzzleUtil.IsInTheBoard(2,2,3,3));
            Debug.Log("True test cases are passed");
            
            Assert.False(PuzzleUtil.IsInTheBoard(3,3,3,3));
            Assert.False(PuzzleUtil.IsInTheBoard(-1,2,3,3));
            Debug.Log("False test cases are passed");
            
            Assert.True(PuzzleUtil.IsInTheBoard(0,0,TestPuzzleEasy.Puzzle.SizeX(), TestPuzzleEasy.Puzzle.SizeY()));
            Debug.Log(1);
            Assert.True(PuzzleUtil.IsInTheBoard(1,1,TestPuzzleEasy.Puzzle.SizeX(), TestPuzzleEasy.Puzzle.SizeY()));
            Debug.Log(2);
            Assert.True(PuzzleUtil.IsInTheBoard(TestPuzzleEasy.Puzzle.SizeX()-1,TestPuzzleEasy.Puzzle.SizeY() - 1,TestPuzzleEasy.Puzzle.SizeX(), TestPuzzleEasy.Puzzle.SizeY()));
            Debug.Log(3);
            Debug.Log("True test with test puzzle cases are passed");

            Assert.False(PuzzleUtil.IsInTheBoard(TestPuzzleEasy.Puzzle.SizeX(),3,TestPuzzleEasy.Puzzle.SizeX(), TestPuzzleEasy.Puzzle.SizeY()));
            Assert.False(PuzzleUtil.IsInTheBoard(-1,2,TestPuzzleEasy.Puzzle.SizeX(), TestPuzzleEasy.Puzzle.SizeY()));
            Debug.Log("False test with test puzzle cases are passed");
        }

        [Test]
        public void ConvertRawPuzzleToPuzzleTest()
        {
            var expectedPuzzle = TestPuzzleEasy.Puzzle;
            var actualPuzzle = PuzzleUtil.ConvertRawPuzzleToPuzzle(TestPuzzleEasy.RawPuzzle);

            Debug.Log(expectedPuzzle.ToString());
            Debug.Log(actualPuzzle.ToString());
            
            Assert.True(expectedPuzzle.Equals(actualPuzzle));
            Debug.Log("Test case is passed");
        }
        
        [Test]
        public void ConvertPuzzleToRawPuzzleTest()
        {
            var expectedPuzzle = TestPuzzleEasy.RawPuzzle;
            var actualPuzzle = PuzzleUtil.ConvertPuzzleToRawPuzzle(TestPuzzleEasy.Puzzle);
            
            Debug.Log(expectedPuzzle.ToString());
            Debug.Log(actualPuzzle.ToString());
            
            Assert.True(expectedPuzzle.Equals(actualPuzzle));
            Debug.Log("Test case is passed");
        }
    }
}