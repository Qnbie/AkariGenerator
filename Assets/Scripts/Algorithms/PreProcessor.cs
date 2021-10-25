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
                        PuzzleUtil.SetNeighbour(x, y, TileStates.Implacable, puzzle);
                    else if ((int) puzzle.PuzzleMatrix[x][y] < 5)
                    {
                        NForNSpace(x, y, puzzle);
                    }
                }
            }

            Debug.Log($"Puzzle is preprocessed\n {puzzle}");
            return puzzle;
        }

        private void NForNSpace(int posX, int posY, Puzzle puzzle)
        {
            int spaceCnt = 0;
            if (posX + 1 < puzzle.SizeX())
                if (puzzle.PuzzleMatrix[posX + 1][posY] == TileStates.Empty)
                    spaceCnt++;
            if (posY + 1 < puzzle.SizeY())
                if (puzzle.PuzzleMatrix[posX][posY + 1] == TileStates.Empty)
                    spaceCnt++;
            if (posX - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX - 1][posY] == TileStates.Empty)
                    spaceCnt++;
            if (posY - 1 >= 0)
                if (puzzle.PuzzleMatrix[posX][posY - 1] == TileStates.Empty)
                    spaceCnt++;
            
            if (spaceCnt == (int) puzzle.PuzzleMatrix[posX][posY])
                PuzzleUtil.SetNeighbour(posX,posY,TileStates.Lamp,puzzle);
        }

    }
}