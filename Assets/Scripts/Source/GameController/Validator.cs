using Source.GameBoard;
using UnityEngine;

namespace Source.GameController
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
            int count = 0;
            bool win = true;
            var board = _gameBoardController.TileMatrix;
            foreach (var tileRow in board)
                foreach (var tile in tileRow)
                {
                    win = tile.IsValid() && win;
                   count++;
                }

            Debug.Log(count);
            return win;
        }
    }
}