using NUnit.Framework;
using UnityEngine;
using Utils.TestData;

namespace Tests.PlayModeTest
{
    [TestFixture]
    public class DataClassTest
    {
        [Test]
        public void RawPuzzleTest()
        {
            var puzzleA = TestPuzzles.GoodRawPuzzle;
            var puzzleB = TestPuzzles.GoodRawPuzzle;
            
            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
        
        [Test]
        public void PuzzleTest()
        {
            var puzzleA = TestPuzzles.GoodPuzzle;
            var puzzleB = TestPuzzles.GoodPuzzle;

            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
    }
}