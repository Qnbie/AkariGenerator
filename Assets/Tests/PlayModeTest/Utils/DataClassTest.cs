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
            var puzzleA = TestPuzzleEasy.GoodRawPuzzle;
            var puzzleB = TestPuzzleEasy.GoodRawPuzzle;
            
            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
        
        [Test]
        public void PuzzleTest()
        {
            var puzzleA = TestPuzzleEasy.GoodPuzzle;
            var puzzleB = TestPuzzleEasy.GoodPuzzle;

            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
    }
}