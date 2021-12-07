using System;
using Algorithms;
using Game.GameBoard;
using Game.GameBoard.Tile;
using Game.GameHelpers;
using UnityEngine;
using Utils.Enums;
using Utils.Helpers;

namespace Game
{
    [RequireComponent(typeof(GameBoardController))]
    public class GameController : LevelLoader
    {

        private GameBoardController _gameBoardController;
        private GameStateMachine _gameStateMachine;
        private GameBoardValidator _gameBoardValidator;
        private AlgorithmController _algorithmController;

        private void Awake()
        {
            _algorithmController = new AlgorithmController();
            _gameBoardController = GetComponent<GameBoardController>();
            _gameStateMachine = new GameStateMachine();
            _gameBoardValidator = new GameBoardValidator(_gameBoardController);
        }

        private void Update()
        {
            if (!_gameStateMachine.NewPhase) return;
            _gameStateMachine.NewPhase = false;
            switch (_gameStateMachine.CurrentGameState)
            {
                case GameState.GameStart:
                    SetUpGame();
                    _gameStateMachine.NextPhase();
                    break;
                case GameState.ActionPhase:
                    break;
                case GameState.EndTurnPhase:
                    if (_gameBoardValidator.BoardIsValid()) GameOver();
                    else _gameStateMachine.NextPhase();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void OnSelection(GoodTileController selectedTile)
        {
            if(selectedTile.lampPlaced)
                _gameBoardController.LightOnAt(selectedTile.position);
            else
                _gameBoardController.LightOffAt(selectedTile.position);
            
            _gameStateMachine.NextPhase();
        }        

        private void SetUpGame()
        {
            _gameBoardController.Populate(
                _algorithmController.GetPuzzle(LevelLoader.GameSize, LevelLoader.GameDifficulty),
                OnSelection);
        }

        private void GameOver()
        {
            LoadNextLevel("WinScene");
        }
    }
}