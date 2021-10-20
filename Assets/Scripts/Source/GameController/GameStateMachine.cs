using System;
using Utils.Enums;

namespace Source.GameController
{
    public class GameStateMachine
    {
        public GameState CurrentGameState { get; private set; }
        public bool NewPhase { get; set; }
        
        public GameStateMachine()
        {
            CurrentGameState = GameState.GameStart;
            NewPhase = true;
        }
        
        public void NextPhase()
        {
            switch (CurrentGameState)
            {
                case GameState.GameStart:
                    CurrentGameState = GameState.ActionPhase;
                    break;
                case GameState.ActionPhase:
                    CurrentGameState = GameState.EndTurnPhase;
                    break;
                case GameState.EndTurnPhase:
                    CurrentGameState = GameState.ActionPhase;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            NewPhase = true;
        }
    }
}