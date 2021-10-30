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
            _preProcessor = new PreProcessor();
        }

        [Test]
        public void ProcessTest()
        {
            var actualPuzzle = _preProcessor.Process(TestPuzzleEasy.Puzzle);
            Assert.True(TestPuzzleEasy.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Easy PreProcessed puzzle passed");
            actualPuzzle = _preProcessor.Process(TestPuzzleNormal.Puzzle);
            Assert.True(TestPuzzleNormal.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Normal PreProcessed puzzle passed");
            actualPuzzle = _preProcessor.Process(TestPuzzleHard.Puzzle);
            Assert.True(TestPuzzleHard.PreProcessedPuzzle.Equals(actualPuzzle));
            Debug.Log("Hard PreProcessed puzzle passed");
        }
    }
}