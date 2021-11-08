using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.Enums;

namespace Tests
{
    [TestFixture]
    public class GeneratorTest
    {
        private Generator _generator;
        private PuzzleSolver _solver;
        
        [SetUp]
        public void SetUpTest()
        {
            var validator = new Validator();
            _solver = new PuzzleSolver(validator);
            _generator = new Generator(validator);
        }

        [Test]
        public void GeneratePuzzleTest()
        {
            var generatedPuzzle = _generator.GeneratePuzzle(new Vector2Int(5, 5));
            Debug.Log($"Puzzle Generator is working \n {generatedPuzzle}");
        }
    }
}