using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer), typeof(Collider))]
    public class GoodTileController : TileBase
    {
        public event IsSelectedDelegate OnSelect;

        public bool IsLighted => _lightCounter > 0;

        [SerializeField]private int _lightCounter = 0;
        
        public override bool LightOn()
        {
            _lightCounter++;
            MyTileRenderer.TurnOn();
            return true;
        }

        public override bool LightOff()
        {
            _lightCounter--;
            if (_lightCounter <= 0)
            {
                _lightCounter = 0;
                MyTileRenderer.TurnOff();
            }
            return true;
        }

        public override bool IsValid()
        {
            if (IsLighted && isSelected)
            {
                Debug.Log(name + " is wrong");
                MyTileRenderer.NotAllowed();
            }
            if (IsLighted ^ isSelected)
            {
                MyTileRenderer.Allowed();
                return true;
            }
            return false;
        }

        private void OnMouseDown()
        {
            isSelected = !isSelected;
            if(isSelected) MyTileRenderer.AddSelection();
            else MyTileRenderer.RemoveSelection();
            OnSelect?.Invoke(this);
        }
    }

    public delegate void IsSelectedDelegate(GoodTileController selectedTile);
}