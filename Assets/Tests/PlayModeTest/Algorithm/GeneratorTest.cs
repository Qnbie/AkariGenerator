using Algorithms;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayModeTest.Algorithm
{
    [TestFixture]
    public class GeneratorTest
    {
        private Generator _generator;
        
        [SetUp]
        public void SetUpTest()
        {
            _generator = new Generator();
        }

        [Test]
        public void GenerateLittlePuzzleTest()
        {
            var generatedPuzzle = _generator.GeneratePuzzle(new Vector2Int(5, 5));
            Debug.Log($"Puzzle Generator is working \n {generatedPuzzle}");
        }
        
        [Test]
        public void GenerateNormalPuzzleTest()
        {
            var generatedPuzzle = _generator.GeneratePuzzle(new Vector2Int(10, 10));
            Debug.Log($"Puzzle Generator is working \n {generatedPuzzle}");
        }
        
        [Test]
        public void GenerateBigPuzzleTest()
        {
            var generatedPuzzle = _generator.GeneratePuzzle(new Vector2Int(14, 14));
            Debug.Log($"Puzzle Generator is working \n {generatedPuzzle}");
        }
    }
}