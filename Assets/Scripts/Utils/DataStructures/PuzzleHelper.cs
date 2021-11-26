using Utils.Enums;
using Utils.Helpers;

namespace Utils.DataStructures
{
    public partial class Puzzle
    {
        public bool PlaceIsEqual(int x, int y, TileStates expectedTile) => 
            PuzzleUtil.IsInTheBoard(x,y, SizeX(), SizeY()) &&
            PuzzleMatrix[x][y] == expectedTile;
        
        public void SetNeighbour(int posX, int posY, TileStates value)
        {
            if (posX + 1 < SizeX() && 
                PuzzleMatrix[posX + 1][posY] == TileStates.Empty) 
                PuzzleMatrix[posX + 1][posY] = value;
            if (posY + 1 < SizeY() && 
                PuzzleMatrix[posX][posY + 1] == TileStates.Empty)
                PuzzleMatrix[posX][posY + 1] = value;
            if (posX - 1 >= 0 && 
                PuzzleMatrix[posX - 1][posY] == TileStates.Empty)
                PuzzleMatrix[posX - 1][posY] = value;
            if (posY - 1 >= 0 &&
                PuzzleMatrix[posX][posY - 1] == TileStates.Empty)
                PuzzleMatrix[posX][posY - 1] = value;
        }

        public void TurnOnLamps(Solution lampPositions)
        {
            AddElements(lampPositions.Positions,TileStates.Lamp);
            foreach (var lampPos in lampPositions.Positions)
            {
                var isStop = new bool[4];
                var index = 0;
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
                {
                    if (!isStop[0])
                        if( lampPos.x + 1 + index < SizeX())
                        {
                            if ((int)PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] < 6)
                                isStop[0] = true;
                            else if (PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Empty ||
                                     PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] == TileStates.Implacable)
                                PuzzleMatrix[lampPos.x + 1 + index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[0] = true;
                    if (!isStop[1])
                        if( lampPos.x - 1 - index >= 0)
                        {
                            if ((int)PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] < 6)
                                isStop[1] = true;
                            else if (PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Empty ||
                                     PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] == TileStates.Implacable)
                                PuzzleMatrix[lampPos.x - 1 - index][lampPos.y] = TileStates.Lit;
                        }
                        else isStop[1] = true;
                    if (!isStop[2])
                        if( lampPos.y + 1 + index < SizeY())
                        {
                            if ((int)PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] < 6)
                                isStop[2] = true;
                            else if (PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Empty ||
                                     PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] == TileStates.Implacable)
                                PuzzleMatrix[lampPos.x][lampPos.y + 1 + index] = TileStates.Lit;
                        }
                        else isStop[2] = true;
                    if (!isStop[3])
                        if( lampPos.y - 1 - index >= 0)
                        {
                            if ((int)PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] < 6)
                                isStop[3] = true;
                            else if (PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Empty ||
                                     PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] == TileStates.Implacable)
                                PuzzleMatrix[lampPos.x][lampPos.y - 1 - index] = TileStates.Lit;
                        }
                        else isStop[3] = true;

                    index++;
                }
            }
        }

        public void TurnOfLamps()
        {
            for(var x = 0; x < SizeX(); x++)
            {
                for (var y = 0; y < SizeY(); y++)
                {
                    if (PuzzleMatrix[x][y] == TileStates.Lamp || PuzzleMatrix[x][y] == TileStates.Lit)
                        PuzzleMatrix[x][y] = TileStates.Empty;
                }
            }
        }
    }
}