using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.DataStructures;
using Utils.TestData;

namespace Tests.PlayModeTest.Algorithm
{
    [TestFixture]
    public class ValidatorTest
    {
        private Validator _validator;

        [SetUp]
        public void SetUpTest()
        {
            _validator = new Validator();
        }

        [Test]
        public void PuzzleIsSolved()
        {
            Assert.True(_validator.PuzzleIsSolved(TestPuzzleEasy.Puzzle, TestPuzzleEasy.Solution));
            Debug.Log("EasyPuzzle is passed");
            Assert.True(_validator.PuzzleIsSolved(TestPuzzleNormal.Puzzle, TestPuzzleNormal.Solution));
            Debug.Log("NormalPuzzle is passed");
            Assert.True(_validator.PuzzleIsSolved(TestPuzzleHard.Puzzle, TestPuzzleHard.Solution));
            Debug.Log("HardPuzzle is passed");
        }

        [Test]
        public void PuzzleIsFull()
        {
            var falseSolution = new Solution(TestPuzzleEasy.Solution.Positions.GetRange(0, 3));
            Assert.False(_validator.PuzzleIsSolved(TestPuzzleEasy.Puzzle, falseSolution));
            Debug.Log("EasyPuzzle is passed");
            falseSolution = new Solution(TestPuzzleNormal.Solution.Positions.GetRange(0, 3));
            Assert.False(_validator.PuzzleIsSolved(TestPuzzleNormal.Puzzle, falseSolution));
            Debug.Log("NormalPuzzle is passed");
            falseSolution = new Solution(TestPuzzleHard.Solution.Positions.GetRange(0, 3));
            Assert.False(_validator.PuzzleIsSolved(TestPuzzleHard.Puzzle, falseSolution));
            Debug.Log("HardPuzzle is passed");
        }

        [Test]
        public void WallIsSatisfied()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.True(_validator.WallIsSatisfied(1,1,TestWall.GoodWalls[i]));
                Debug.Log($"Good Test Wall {i} is passed");
            }
            for (int i = 0; i < 5; i++)
            {
                Assert.False(_validator.WallIsSatisfied(1,1,TestWall.BadWalls[i]));
                Debug.Log($"Bad Test Wall {i} is passed");
            }
        }

        [Test]
        public void LampsCheck()
        {
            Debug.Log("Check For Wall Y");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.True(_validator.LampsCheck(TestLamp.GoodYPuzzles[i], TestLamp.YSolutions[j]));
                    Debug.Log($"{i} GoodYPuzzle {j} YSolution is passed");
                }
            }
            for (int j = 0; j < 2; j++)
            {
                Assert.False(_validator.LampsCheck(TestLamp.BadYPuzzles, TestLamp.YSolutions[j]));
                Debug.Log($"BadYPuzzle {j} YSolution is passed");
            }
            
            Debug.Log("Check For Wall X");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Assert.True(_validator.LampsCheck(TestLamp.GoodXPuzzles[i], TestLamp.XSolutions[j]));
                    Debug.Log($"{i} GoodXPuzzle {j} XSolution is passed");

                }
            }
            for (int j = 0; j < 2; j++)
            {
                Assert.False(_validator.LampsCheck(TestLamp.BadXPuzzles, TestLamp.XSolutions[j]));
                Debug.Log($"BadXPuzzle {j} XSolution is passed");
            }
        }
    }
}