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
                    _gameStateMachine.NextPhase();
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
        
        private void OnSelection(GoodTileController selectedTile)
        {
            if(selectedTile.IsSelected)
                _gameBoardController.LightOnAt(selectedTile.Position);
            else
                _gameBoardController.LightOffAt(selectedTile.Position);
            
            _gameStateMachine.NextPhase();
        }        

        private void SetUpGame()
        {
            _gameBoardController.Populate(OnSelection);
        }

        private void GameOver()
        {
            Debug.Log("YouWin!!!!!!!!!!");
        }
    }
}