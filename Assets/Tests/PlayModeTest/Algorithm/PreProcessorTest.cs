using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.TestData;

namespace Tests
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
        public void ProcessTest()
        {
            var actualPuzzle = _preProcessor.Process(TestPuzzleEasy.Puzzle);
            Debug.Log($"Expected \n {TestPuzzleEasy.PreProcessedPuzzle}");
            Debug.Log($"Actual \n {actualPuzzle}");
            Assert.True(TestPuzzleEasy.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Easy PreProcessed puzzle passed");
            actualPuzzle = _preProcessor.Process(TestPuzzleNormal.Puzzle);
            Assert.True(TestPuzzleNormal.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Normal PreProcessed puzzle passed");
            actualPuzzle = _preProcessor.Process(TestPuzzleHard.Puzzle);
            Debug.Log($"Expected \n {TestPuzzleHard.PreProcessedPuzzle}");
            Debug.Log($"Actual \n {actualPuzzle}");
            Assert.True(TestPuzzleHard.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Hard PreProcessed puzzle passed");
        }
    }
}