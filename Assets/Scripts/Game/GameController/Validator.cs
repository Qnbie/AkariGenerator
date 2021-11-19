﻿using System.Linq;
using Game.GameBoard;
using UnityEngine;

namespace Game.GameController
{
    public class Validator
    {
        private readonly GameBoardController _gameBoardController;

        public Validator(GameBoardController gameBoardController)
        {
            _gameBoardController = gameBoardController;
        }

        public bool BoardIsValid()
        {
            var count = 0;
            var win = true;
            var board = _gameBoardController.TileMatrix;
            foreach (var tile in board.SelectMany(tileRow => tileRow))
            {
                win = tile.IsValid() && win;
                count++;
            }

            Debug.Log(count);
            return win;
        }
    }
}