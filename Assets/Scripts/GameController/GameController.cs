using System;
using GameBoard;
using GameBoard.Tile;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameController
{
    [RequireComponent(typeof(GameBoardController))]
    public class GameController : MonoBehaviour
    {

        private GameBoardController _gameBoardController;
        private GameStateMachine _gameStateMachine;
        private Validator _validator;

        private void Awake()
        {
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
                case GameStateMachine.GameState.GameStart:
                    SetUpGame();
                    break;
                case GameStateMachine.GameState.ActionPhase:
                    break;
                case GameStateMachine.GameState.EndTurnPhase:
                    if (_validator.BoardIsValid()) GameOver();
                    else _gameStateMachine.NextPhase();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetUpGame()
        {
            _gameBoardController.Populate(OnSelection);
        }

        private void OnSelection(GoodTileController selectedTile)
        {
            if(selectedTile.IsSelected)
                _gameBoardController.LightOffAt(selectedTile.position);
            _gameBoardController.LightOnAt(selectedTile.position);
        }

        private void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}