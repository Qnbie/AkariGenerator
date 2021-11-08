using System;
using System.Collections.Generic;
using GameBoard;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class PreProcessor
    {
        private Validator _validator;

        public PreProcessor(Validator validator)
        {
            _validator = validator;
        }

        public Puzzle Process(Puzzle puzzle)
        {
            List<Vector2Int> numberedWalls = new List<Vector2Int>();
            // Zero and Four Check
            for (int x = 0; x < puzzle.SizeX(); x++)
                for (int y = 0; y < puzzle.SizeY(); y++)
                    if (puzzle.PuzzleMatrix[x][y] == TileStates.Zero) 
                        puzzle.SetNeighbour(x, y, TileStates.Implacable);
                    else if((puzzle.PuzzleMatrix[x][y] == TileStates.Four))
                        puzzle.SetNeighbour(x,y,TileStates.Lamp);
                    else if((int)puzzle.PuzzleMatrix[x][y] < 5)
                        numberedWalls.Add(new Vector2Int(x,y));
            
            // Other wall check
            Boolean optimized = false;
            int optStep = 0;
            while (!optimized && 5 > optStep)
            {
                optimized = OtherWallCheck(puzzle,numberedWalls);
                optStep++;
            }
            
            puzzle.TurnOnLamps(new Solution(puzzle.GetElementPositions(TileStates.Lamp)));
            return puzzle;
        }

        public bool OtherWallCheck(Puzzle puzzle, List<Vector2Int> numberedWalls)
        {
            bool otherWallsAreCorrect = true;
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
            int emptyCnt = 0;
            if (posX + 1 < puzzle.SizeX())
                if (puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Empty)
                    emptyCnt++;
            if (posY + 1 < puzzle.SizeY())
                if (puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Empty)
                    emptyCnt++;
            if (posX - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Empty)
                    emptyCnt++;
            if (posY - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Empty)
                    emptyCnt++;
            
            int lampCnt = 0;
            if (posX + 1 < puzzle.SizeX())
                if (puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Lamp)
                    lampCnt++;
            if (posY + 1 < puzzle.SizeY())
                if (puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Lamp)
                    lampCnt++;
            if (posX - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Lamp)
                    lampCnt++;
            if (posY - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Lamp)
                    lampCnt++;

            if (emptyCnt == (int) puzzle.PuzzleMatrix[posX][posY] - lampCnt)
            {
                puzzle.SetNeighbour(posX,posY,TileStates.Lamp);
                return false;
            }
            return true;
        }

    }
}