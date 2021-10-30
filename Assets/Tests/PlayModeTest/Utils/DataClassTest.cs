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
            var puzzleA = TestPuzzleEasy.RawPuzzle;
            var puzzleB = TestPuzzleEasy.RawPuzzle;
            
            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
        
        [Test]
        public void PuzzleTest()
        {
            var puzzleA = TestPuzzleEasy.Puzzle;
            var puzzleB = TestPuzzleEasy.Puzzle;

            Assert.True(puzzleA.Equals(puzzleB));
            Debug.Log("Test case is passed");
        }
    }
}