using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;
using Utils.Helpers;

namespace Menu
{
    public class DifficultyButton : MonoBehaviour
    {
        
        private Text _difficultyText;
        private int _currentIndex;

        private void Awake()
        {
            _difficultyText = GetComponentInChildren<Text>();
            _currentIndex = -1;
        }

        public void DifficultyOnClick()
        {
            _currentIndex = (_currentIndex + 1) % MapperUtil.DifficultyValues.Count;
            _difficultyText.text = MapperUtil.DifficultyValues[_currentIndex].Item1.ToString();
            _difficultyText.color = IsValid() ? Color.black : Color.red;
        }
        
        public bool IsValid()
        {
            return _currentIndex != -1 && MapperUtil.DifficultyValues[_currentIndex].Item2;
        }
        
        public Difficulty GetValue()
        {
            return MapperUtil.DifficultyValues[_currentIndex].Item1;
        }
    }
}