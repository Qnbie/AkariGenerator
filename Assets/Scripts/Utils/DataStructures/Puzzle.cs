using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Enums;
using Utils.StaticClasses;

namespace Utils.DataStructures
{
    public class Puzzle : IEquatable<Puzzle>
    {
        public Difficulty PuzzleDifficulty;
        public List<List<TileStates>> PuzzleMatrix;
        
        public Puzzle(){}
        
        public Puzzle(List<List<TileStates>> getEmptyPuzzle)
        {
            PuzzleMatrix = new List<List<TileStates>>();
        }

        public Puzzle(RawPuzzle rawPuzzle)
        {
            var puzzleTmp = PuzzleUtil.ConvertRawPuzzleToPuzzle(rawPuzzle);
            this.PuzzleDifficulty = puzzleTmp.PuzzleDifficulty;
            this.PuzzleMatrix = puzzleTmp.PuzzleMatrix;
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
            for (int i = 0; i < SizeX(); i++)
            {
                for (int j = 0; j < SizeY(); j++)
                {
                    if (PuzzleMatrix[i][j] != other.PuzzleMatrix[i][j]) return false;
                }
            }
            
            return true;
        }
    }
}