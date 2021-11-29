using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils.Enums;
using Utils.Helpers;

namespace Utils.DataStructures
{
    public partial class Puzzle : IEquatable<Puzzle>
    {
        public Difficulty DifficultyLevel;
        public readonly List<List<TileStates>> PuzzleMatrix;

        public Puzzle(Puzzle otherPuzzle)
        {
            DifficultyLevel = otherPuzzle.DifficultyLevel;
            PuzzleMatrix = new List<List<TileStates>>();
            for (var x = 0; x < otherPuzzle.SizeX(); x++)
            {
                PuzzleMatrix.Add(new List<TileStates>());
                for (var y = 0; y < otherPuzzle.SizeY(); y++)
                {
                    PuzzleMatrix[x].Add(TileStates.Empty);
                    PuzzleMatrix[x][y] = otherPuzzle.PuzzleMatrix[x][y];
                }
            }
        }
        
        public Puzzle(List<List<TileStates>> puzzleMatrix)
        {
            PuzzleMatrix = puzzleMatrix;
            DifficultyLevel = Difficulty.Medium;
        }
        
        public Puzzle(List<List<TileStates>> puzzleMatrix, Difficulty difficulty)
        {
            PuzzleMatrix = puzzleMatrix;
            DifficultyLevel = difficulty;
        }

        public Puzzle(Vector2Int size)
        {
            PuzzleMatrix = PuzzleUtil.GetEmptyPuzzleMatrix(size);
        }

        public int SizeX() => PuzzleMatrix.Count;
        public int SizeY() => PuzzleMatrix[0].Count;
        
        public bool Equals(Puzzle other)
        {
            if (other == null) return false;
            if (SizeX() != other.SizeX() || SizeY() != other.SizeY()) return false;
            for (var i = 0; i < SizeX(); i++)
            {
                for (var j = 0; j < SizeY(); j++)
                {
                    if (PuzzleMatrix[i][j] != other.PuzzleMatrix[i][j]) return false;
                }
            }
            
            return true;
        }

        public List<Vector2Int> GetElementPositions(TileStates tileStates)
        {
            var elementPositions = new List<Vector2Int>();
            for (var x = 0; x < SizeX(); x++)
                for (var y = 0; y < SizeY(); y++)
                    if (PuzzleMatrix[x][y] == tileStates)
                        elementPositions.Add(new Vector2Int(x,y)); 
            return elementPositions;
        }

        public void AddElements(IEnumerable<Vector2Int> elementsPos, TileStates tileState)
        {
            foreach (var lampPos in elementsPos)
                PuzzleMatrix[lampPos.x][lampPos.y] = tileState;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Difficulty: {DifficultyLevel}");
            stringBuilder.AppendLine("PuzzleMatrix");
            foreach (var strTmp in PuzzleMatrix.Select(puzzleRow => puzzleRow
                .Aggregate("", (current, tile) => current + $"{tile}, ")))
            {
                stringBuilder.AppendLine(strTmp);
            }
            return stringBuilder.ToString();
        }
    }
}