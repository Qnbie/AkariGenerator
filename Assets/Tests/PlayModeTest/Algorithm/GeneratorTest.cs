﻿using Algorithms;
using NUnit.Framework;
using UnityEngine;

namespace Tests.PlayModeTest.Algorithm
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