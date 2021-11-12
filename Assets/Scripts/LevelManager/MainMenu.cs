using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace LevelManager
{
    public class MainMenu : MonoBehaviour
    {
        private DifficultyButton _difficulty;
        private SizeButton _size;
        
        private void Awake()
        {
            _difficulty = GetComponentInChildren<DifficultyButton>();
            _size = GetComponentInChildren<SizeButton>();
        }
        
        public void StartGameOnClick()
        {
            if (_difficulty.IsValid() && _size.IsValid())
                GetComponent<LevelLoader>().LoadNextLevel(
                    "GameScene",
                    _size.GetValue(),
                    _difficulty.GetValue());
        }
    }
}
