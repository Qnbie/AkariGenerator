using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.TestData;

namespace Tests.PlayModeTest.Algorithm
{
    [TestFixture]
    public class PreProcessorTest
    {
        private PreProcessor _preProcessor;
        
        [SetUp]
        public void SetUpTest()
        {
            _preProcessor = new PreProcessor(new Validator());
        }

        [Test]
        public void PreProcessTestWithEasyPuzzle()
        {
            var actualPuzzle = _preProcessor.Process(TestPuzzleEasy.Puzzle);
            Debug.Log($"Expected \n {TestPuzzleEasy.PreProcessedPuzzle}");
            Debug.Log($"Actual \n {actualPuzzle}");
            Assert.True(TestPuzzleEasy.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Easy PreProcessed puzzle passed");
        }
        
        [Test]
        public void PreProcessTestWithMediumPuzzle()
        {
            var actualPuzzle = _preProcessor.Process(TestPuzzleNormal.Puzzle);
            Debug.Log($"Expected \n {TestPuzzleNormal.PreProcessedPuzzle}");
            Debug.Log($"Actual \n {actualPuzzle}");
            Assert.True(TestPuzzleNormal.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Normal PreProcessed puzzle passed");
        }
        
        [Test]
        public void PreProcessTestWithHardPuzzle()
        {
            var actualPuzzle = _preProcessor.Process(TestPuzzleHard.Puzzle);
            Debug.Log($"Expected \n {TestPuzzleHard.PreProcessedPuzzle}");
            Debug.Log($"Actual \n {actualPuzzle}");
            Assert.True(TestPuzzleHard.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Hard PreProcessed puzzle passed");
        }
    }
}