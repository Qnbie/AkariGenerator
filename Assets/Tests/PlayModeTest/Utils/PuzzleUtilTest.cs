using NUnit.Framework;
using UnityEngine;
using Utils.Helpers;
using Utils.TestData;

namespace Tests.PlayModeTest.Utils
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
    }
}