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
            var actualPuzzle = _preProcessor.Process(TestPuzzles.GoodPuzzle);
            var expectedPuzzle = TestPuzzles.PreProcessedPuzzle;
            
            Debug.Log(actualPuzzle);
            Debug.Log(expectedPuzzle);
            
            Assert.True(expectedPuzzle.Equals(actualPuzzle));
        }
    }
}