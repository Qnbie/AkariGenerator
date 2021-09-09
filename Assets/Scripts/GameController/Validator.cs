using GameBoard;

namespace GameController
{
    public class Validator
    {
        private GameBoardController _gameBoardController;

        public Validator(GameBoardController gameBoardController)
        {
            _gameBoardController = gameBoardController;
        }

        public bool BoardIsValid()
        {
            bool win = true;
            var board = _gameBoardController.TileMatrix;
            foreach (var tileRow in board)
                foreach (var tile in tileRow)
                    win = win && tile.IsValid();

            return win;
        }
    }
}