using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utils.StaticClasses;

namespace LevelManager
{
    public class SizeButton : MonoBehaviour
    {
        private Text _sizeText;
        private int _currentIndex;

        private void Awake()
        {
            _sizeText = GetComponentInChildren<Text>();
            _currentIndex = -1;
        }

        public void SizeOnClick()
        {
            _currentIndex = (_currentIndex + 1) % MapperUtil.SizeValues.Count;
            var currentItem = MapperUtil.SizeValues[_currentIndex].Item1;
            _sizeText.text = $"{currentItem.x} x {currentItem.y}";
            if (IsValid())
                _sizeText.color = Color.black;
            else
                _sizeText.color = Color.red;
        }

        public bool IsValid()
        {
            return MapperUtil.SizeValues[_currentIndex].Item2;
        }
        
        public Vector2Int GetValue()
        {
            return MapperUtil.SizeValues[_currentIndex].Item1;
        }
    }
}