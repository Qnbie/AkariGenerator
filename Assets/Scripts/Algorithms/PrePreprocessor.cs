using GameBoard;
using Utils.Enums;

namespace Algorithms
{
    public class PrePreprocessor
    {
        private GameBoardStats _board;
        
        public PrePreprocessor(GameBoardStats gameBoardStats)
        {
            _board = gameBoardStats;
        }

        public void Process()
        {
            for (int x = 0; x < _board.Size.x; x++)
            {
                for (int y = 0; y < _board.Size.y; y++)
                {
                    if (_board.Board[x, y] == 0) SetNeighbour(x, y, 6);
                    else if ((int)_board.Board[x, y] < 5) NForNSpace(x,y);
                }
            }
        }

        void NForNSpace(int posX, int posY)
        {
            int n = (int) _board.Board[posX, posY];
            int spaceCnt = 0;
            if (posX + 1 < _board.Size.x)
                if (_board.Board[posX + 1, posY] != TileStates.Empty)
                {
                    spaceCnt++;
                }
            if (posY + 1 < _board.Size.y)
                if (_board.Board[posX + 1, posY] != TileStates.Empty)
                {
                    spaceCnt++;
                }
            if (posX - 1 >= 0)
                if (_board.Board[posX + 1, posY] != TileStates.Empty)
                {
                    spaceCnt++;
                }
            if (posY - 1 >= 0)
                if (_board.Board[posX + 1, posY] != TileStates.Empty)
                {
                    spaceCnt++;
                }
            if (spaceCnt == n) SetNeighbour(posX,posY,n);
        }
        void SetNeighbour(int posX, int posY, int value)
        {
            if (posX + 1 < _board.Size.x) _board.Board[posX+1, posY] = (TileStates) value;
            if (posY + 1 < _board.Size.y) _board.Board[posX, posY+1] = (TileStates) value;
            if (posX - 1 >= 0) _board.Board[posX-1, posY] = (TileStates) value;
            if (posY - 1 >= 0) _board.Board[posX, posY+1] = (TileStates) value;
        }
    }
}