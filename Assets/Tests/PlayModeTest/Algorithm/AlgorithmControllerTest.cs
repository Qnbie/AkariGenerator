using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.Enums;

namespace Tests.PlayModeTest.Algorithm
{
    [TestFixture]
    public class AlgorithmControllerTest
    {
        private AlgorithmController _algorithmController;
        
        [SetUp]
        public void SetUpTest()
        {
            _algorithmController = new AlgorithmController();
        }

        [Test]
        public void GetEasyPuzzle()
        {
            var puzzle = _algorithmController.GetPuzzle(new Vector2Int(5,5), Difficulty.Easy);
            Debug.Log($"Generation is done \n {puzzle}");
        }
        
        [Test]
        public void GetMediumPuzzle()
        {
            var puzzle = _algorithmController.GetPuzzle(new Vector2Int(7,7), Difficulty.Medium);
            Debug.Log($"Generation is done \n {puzzle}");
        }
        
        [Test]
        public void GetHardPuzzle()
        {
            var puzzle = _algorithmController.GetPuzzle(new Vector2Int(9,9), Difficulty.Hard);
            Debug.Log($"Generation is done \n {puzzle}");
        }
    }
}