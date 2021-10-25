using System;
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

        public List<Vector2Int> GetLampPositions()
        {
            List<Vector2Int> lampPositions = new List<Vector2Int>();
            for (int x = 0; x < SizeX(); x++)
            {
                for (int y = 0; y < SizeY(); y++)
                {
                    if (PuzzleMatrix[x][y] == TileStates.Lamp)
                        lampPositions.Add(new Vector2Int(x,y));
                }
            }
            return lampPositions;
        }

        public Puzzle AddLamps(List<Vector2Int> lampPositions)
        {
            foreach (var lampPos in lampPositions)
            {
                PuzzleMatrix[lampPos.x][lampPos.y] = TileStates.Lamp;
            }
            Debug.Log($"Lamps are added \n {this}");
            return this;
        }
        
        public void TurnOfLamps()
        {
            for (int x = 0; x < SizeX(); x++)
            {
                for (int y = 0; y < SizeY(); y++)
                {
                    if (PuzzleMatrix[x][y] == TileStates.Lit)
                        PuzzleMatrix[x][y] = TileStates.Empty;
                }
            }
            Debug.Log($"Lamps are off \n {this}");
        }
        
        public Puzzle TurnOnLamps()
        {
            var lampPositions = GetLampPositions();
            
            foreach (Vector2Int lampPos in lampPositions)
            {
                bool[] isStop = new bool[4];
                int index = 0;
                while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
                {
                    if (!isStop[0])
                        if( lampPos.x + 1 + index < SizeX())
                        {
                            if ((int)PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] < 6)
                                isStop[0] = true;
                            else if (PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Empty)
                                PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[0] = true;
                    if (!isStop[1])
                        if( lampPos.x - 1 - index >= 0)
                        {
                            if ((int)PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] < 6)
                                isStop[1] = true;
                            else if (PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Empty)
                                PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[1] = true;
                    if (!isStop[2])
                        if( lampPos.y + 1 + index < SizeX())
                        {
                            if ((int)PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] < 6)
                                isStop[2] = true;
                            else if (PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Empty)
                                PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] = TileStates.Lit;
                        }
                        else isStop[2] = true;
                    if (!isStop[3])
                        if( lampPos.y - 1 - index >= 0)
                        {
                            if ((int)PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] < 6)
                                isStop[3] = true;
                            else if (PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Empty)
                                PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] = TileStates.Lit;
                        }
                        else isStop[3] = true;

                    index++;
                }
            }

            Debug.Log($"Lamps are on \n {this}");
            return this;
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