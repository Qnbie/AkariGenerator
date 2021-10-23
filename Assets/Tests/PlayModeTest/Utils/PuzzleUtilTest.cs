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
            
            Assert.True(PuzzleUtil.IsInTheBoard(0,0,TestPuzzles.GoodPuzzle.SizeX(), TestPuzzles.GoodPuzzle.SizeY()));
            Debug.Log(1);
            Assert.True(PuzzleUtil.IsInTheBoard(1,1,TestPuzzles.GoodPuzzle.SizeX(), TestPuzzles.GoodPuzzle.SizeY()));
            Debug.Log(2);
            Assert.True(PuzzleUtil.IsInTheBoard(TestPuzzles.GoodPuzzle.SizeX()-1,TestPuzzles.GoodPuzzle.SizeY() - 1,TestPuzzles.GoodPuzzle.SizeX(), TestPuzzles.GoodPuzzle.SizeY()));
            Debug.Log(3);
            Debug.Log("True test with test puzzle cases are passed");

            Assert.False(PuzzleUtil.IsInTheBoard(TestPuzzles.GoodPuzzle.SizeX(),3,TestPuzzles.GoodPuzzle.SizeX(), TestPuzzles.GoodPuzzle.SizeY()));
            Assert.False(PuzzleUtil.IsInTheBoard(-1,2,TestPuzzles.GoodPuzzle.SizeX(), TestPuzzles.GoodPuzzle.SizeY()));
            Debug.Log("False test with test puzzle cases are passed");
        }

        [Test]
        public void ConvertRawPuzzleToPuzzleTest()
        {
            var expectedPuzzle = TestPuzzles.GoodPuzzle;
            var actualPuzzle = PuzzleUtil.ConvertRawPuzzleToPuzzle(TestPuzzles.GoodRawPuzzle);

            Debug.Log(expectedPuzzle.ToString());
            Debug.Log(actualPuzzle.ToString());
            
            Assert.True(expectedPuzzle.Equals(actualPuzzle));
            Debug.Log("Test case is passed");
        }
        
        [Test]
        public void ConvertPuzzleToRawPuzzleTest()
        {
            var expectedPuzzle = TestPuzzles.GoodRawPuzzle;
            var actualPuzzle = PuzzleUtil.ConvertPuzzleToRawPuzzle(TestPuzzles.GoodPuzzle);
            
            Debug.Log(expectedPuzzle.ToString());
            Debug.Log(actualPuzzle.ToString());
            
            Assert.True(expectedPuzzle.Equals(actualPuzzle));
            Debug.Log("Test case is passed");
        }
    }
}