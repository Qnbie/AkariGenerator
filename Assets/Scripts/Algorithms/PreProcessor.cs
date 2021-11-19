using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Algorithms
{
    public class PreProcessor
    {
        private const int MaxOptimizationLevel = 5;
        
        private readonly Validator _validator;

        public PreProcessor(Validator validator)
        {
            _validator = validator;
        }

        public Puzzle Process(Puzzle puzzle)
        {
            var numberedWalls = new List<Vector2Int>();
            // Zero and Four Check
            for (int x = 0; x < puzzle.SizeX(); x++)
                for (int y = 0; y < puzzle.SizeY(); y++)
                    switch (puzzle.PuzzleMatrix[x][y])
                    {
                        case TileStates.Zero:
                            puzzle.SetNeighbour(x, y, TileStates.Implacable);
                            break;
                        case TileStates.Four:
                            puzzle.SetNeighbour(x,y,TileStates.Lamp);
                            break;
                        default:
                        {
                            if((int)puzzle.PuzzleMatrix[x][y] < 5)
                                numberedWalls.Add(new Vector2Int(x,y));
                            break;
                        }
                    }
            
            // Other wall check
            Boolean optimized = false;
            int optStep = 0;
            while (!optimized && MaxOptimizationLevel > optStep)
            {
                optimized = OtherWallCheck(puzzle,numberedWalls);
                optStep++;
            }
            
            puzzle.TurnOnLamps(new Solution(puzzle.GetElementPositions(TileStates.Lamp)));
            return puzzle;
        }

        private bool OtherWallCheck(Puzzle puzzle, IEnumerable<Vector2Int> numberedWalls)
        {
            var otherWallsAreCorrect = true;
            foreach (var wall in numberedWalls)
                if ((int) puzzle.PuzzleMatrix[wall.x][wall.y] < 4)
                    if (_validator.WallIsSatisfied(wall.x, wall.y, puzzle))
                    {
                        puzzle.SetNeighbour(wall.x, wall.y, TileStates.Implacable);
                        otherWallsAreCorrect = false;
                    }
                    else
                    {
                        otherWallsAreCorrect = SatisfyWallIfItCan(wall.x, wall.y, puzzle);
                    }

            return otherWallsAreCorrect;
        }
        
        private bool SatisfyWallIfItCan(int posX, int posY, Puzzle puzzle)
        {
            var emptyCnt = 0;
            if (posX + 1 < puzzle.SizeX() &&
                puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Empty)
                emptyCnt++;
            if (posY + 1 < puzzle.SizeY() &&
                puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Empty) 
                emptyCnt++;
            if (posX - 1 >= 0 &&
                puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Empty) 
                emptyCnt++;
            if (posY - 1 >= 0 && puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Empty) 
                emptyCnt++;

            var lampCnt = 0;
            if (posX + 1 < puzzle.SizeX() && 
                puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Lamp) 
                lampCnt++;
            if (posY + 1 < puzzle.SizeY() && 
                puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Lamp) 
                lampCnt++;
            if (posX - 1 >= 0 &&
                puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Lamp) 
                lampCnt++;
            if (posY - 1 >= 0 && 
                puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Lamp) 
                lampCnt++;

            if (emptyCnt != (int) puzzle.PuzzleMatrix[posX][posY] - lampCnt) return true;
            puzzle.SetNeighbour(posX,posY,TileStates.Lamp);
            return false;
        }

    }
}