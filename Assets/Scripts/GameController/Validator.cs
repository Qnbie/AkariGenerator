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

        public bool TheGameIsWined()
        {
            return false;
        }
    }
}