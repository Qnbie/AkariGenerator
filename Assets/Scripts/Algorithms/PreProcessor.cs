using GameBoard;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class PreProcessor
    {
        public Puzzle Process(Puzzle puzzle)
        {
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if (puzzle.PuzzleMatrix[x][y] == TileStates.Zero) 
                        puzzle = PuzzleUtil.SetNeighbour(x, y, TileStates.Implacable, puzzle);
                    else if ((int) puzzle.PuzzleMatrix[x][y] < 5)
                    {
                        if((int) puzzle.PuzzleMatrix[x][y] == 4)
                            PuzzleUtil.SetNeighbour(x,y,TileStates.Lamp,puzzle);
                        else
                            puzzle = NForNSpace(x, y, puzzle);
                    }
                }
            }

            Debug.Log($"Puzzle is preprocessed\n {puzzle}");
            return PuzzleUtil.TurnOnLamps(
                puzzle, 
                new Solution(puzzle.GetElementPositions(TileStates.Lamp)));
        }

        private Puzzle NForNSpace(int posX, int posY, Puzzle puzzle)
        {
            int spaceCnt = 0;
            if (posX + 1 < puzzle.SizeX())
                if (puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Empty || 
                    puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Lamp)
                    spaceCnt++;
            if (posY + 1 < puzzle.SizeY())
                if (puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Empty ||
                    puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Lamp)
                    spaceCnt++;
            if (posX - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Empty ||
                    puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Lamp)
                    spaceCnt++;
            if (posY - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Empty ||
                    puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Lamp)
                    spaceCnt++;
            
            if (spaceCnt == (int) puzzle.PuzzleMatrix[posX][posY])
                puzzle = PuzzleUtil.SetNeighbour(posX,posY,TileStates.Lamp,puzzle);
            return puzzle;
        }

    }
}