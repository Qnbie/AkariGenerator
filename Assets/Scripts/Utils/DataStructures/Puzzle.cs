﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utils.Enums;
using Utils.StaticClasses;

namespace Utils.DataStructures
{
    public class Puzzle : IEquatable<Puzzle>
    {
        public Difficulty DifficultyLevel;
        public List<List<TileStates>> PuzzleMatrix;
        
        public Puzzle(){}
        
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

        public Puzzle(RawPuzzle rawPuzzle)
        {
            var puzzleTmp = PuzzleUtil.ConvertRawPuzzleToPuzzle(rawPuzzle);
            this.DifficultyLevel = puzzleTmp.DifficultyLevel;
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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Difficulty: {DifficultyLevel}");
            stringBuilder.AppendLine("PuzzleMatrix");
            foreach (var puzzleRow in PuzzleMatrix)
            {
                string strTmp = "";
                foreach (var tile in puzzleRow)
                {
                    strTmp += $"{tile}, ";
                }

                stringBuilder.AppendLine(strTmp);
            }
            return stringBuilder.ToString();
        }
    }
}