using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Algorithms;
using NUnit.Framework;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Tests.PlayModeTest
{
    [TestFixture]
    public class PerformanceTest
    {
        private AlgorithmController _algorithmController;
        private Stopwatch _stopwatch;

        private const int TestCount = 10;

        [SetUp]
        public void SetUpTest()
        {
            _algorithmController = new AlgorithmController();
            _stopwatch = new Stopwatch();
        }

        [Test]
        public void PuzzleEasy3X3()
        {
            Measure(3, 3, Difficulty.Easy);
        }
        
        [Test]
        public void PuzzleEasy()
        {
            for (int i = 3; i < 10; i++)
            {
                Measure(i,i,Difficulty.Easy);
            }
        }
        
        [Test]
        public void PuzzleMedium()
        {
            for (int i = 3; i < 10; i++)
            {
                Measure(i,i,Difficulty.Medium);
            }
        }
        
        [Test]
        public void PuzzleHard()
        {
            for (int i = 3; i < 10; i++)
            {
                Measure(i,i,Difficulty.Hard);
            }
        }
        
        

        private void Measure(int x, int y, Difficulty difficulty)
        {
            List<long> times = new List<long>();
            List<Puzzle> puzzles = new List<Puzzle>();
            
            for (int i = 0; i < TestCount; i++)
            {
                _stopwatch.Start();
                Puzzle puzzle = _algorithmController.GetPuzzle(new Vector2Int(x, y), difficulty);
                _stopwatch.Stop();
                times.Add(_stopwatch.ElapsedMilliseconds);
                _stopwatch.Reset();
                puzzles.Add(puzzle);
            }

            var finalString = new List<string>();
            
            for (int i = 0; i < TestCount; i++)
            {
                finalString.Add(i + ";" + times[i]);
            }
            
            File.WriteAllLines(difficulty.ToString() + x + "x" + y + ".txt", finalString);
        }
    }
}