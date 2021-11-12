using System;
using Algorithms;
using GameBoard;
using GameBoard.Tile;
using LevelManager;
using UnityEngine;
using Utils.Enums;
using Utils.TestData;

namespace GameController
{
    [RequireComponent(typeof(GameBoardController))]
    public class GameController : MonoBehaviour
    {

        private GameBoardController _gameBoardController;
        private GameStateMachine _gameStateMachine;
        private Validator _validator;
        private AlgorithmController _algorithmController;

        private void Awake()
        {
            _algorithmController = new AlgorithmController();
            _gameBoardController = GetComponent<GameBoardController>();
            _gameStateMachine = new GameStateMachine();
            _validator = new Validator(_gameBoardController);
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
                    if (_validator.BoardIsValid()) GameOver();
                    else _gameStateMachine.NextPhase();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void OnSelection(GoodTileController selectedTile)
        {
            if(selectedTile.isSelected)
                _gameBoardController.LightOnAt(selectedTile.Position);
            else
                _gameBoardController.LightOffAt(selectedTile.Position);
            
            _gameStateMachine.NextPhase();
        }        

        private void SetUpGame()
        {
            _gameBoardController.Puzzle = _algorithmController.GetPuzzle(new Vector2Int(5,5), Difficulty.Easy);
            _gameBoardController.Populate(OnSelection);
        }

        private void GameOver()
        {
            GetComponent<LevelLoader>().LoadNextLevel("WinScene");
        }
    }
}