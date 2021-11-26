using UnityEngine;
using UnityEngine.UI;
using Utils.Helpers;

namespace Menu
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
            _sizeText.color = IsValid() ? Color.black : Color.red;
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