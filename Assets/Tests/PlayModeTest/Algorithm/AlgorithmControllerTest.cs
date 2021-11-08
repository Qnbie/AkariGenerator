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
        [Ignore("Not implemented")]
        public void GetMediumPuzzle()
        {
            var puzzle = _algorithmController.GetPuzzle(new Vector2Int(10,10), Difficulty.Medium);
            Debug.Log($"Generation is done \n {puzzle}");
        }
        
        [Test]
        [Ignore("Not implemented")]
        public void GetHardPuzzle()
        {
            var puzzle = _algorithmController.GetPuzzle(new Vector2Int(14,14), Difficulty.Hard);
            Debug.Log($"Generation is done \n {puzzle}");
        }
    }
}