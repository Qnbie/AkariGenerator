using MainMenu.Buttons;
using UnityEngine;
using Utils.Helpers;

namespace MainMenu
{
    [RequireComponent(typeof(LevelLoader))]
    public class MainMenuController : LevelLoader
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
                LoadNextLevel(
                    "GameScene",
                    _size.GetValue(),
                    _difficulty.GetValue());
        }
    }
}
