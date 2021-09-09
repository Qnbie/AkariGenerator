using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer))]
    public class GoodTileController : TileBase
    {
        public event IsSelectedDelegate OnSelect;

        public Vector2 position;
        public bool IsLighted { get; set; }

        public override bool LightOn()
        {
            IsLighted = true;
            MyTileRenderer.SwitchAnim();
            return true;
        }

        public override void LightOff()
        {
            MyTileRenderer.SwitchAnim();
            IsLighted = false;
        }

        public override bool IsValid()
        {
            if (IsLighted ^ IsSelected)
            {
                return true;
            }
            MyTileRenderer.WrongAnim();
            return false;
        }

        private void OnMouseDown()
        {
            IsSelected = !IsSelected;
            OnSelect?.Invoke(this);
        }
    }

    public delegate void IsSelectedDelegate(GoodTileController selectedTile);
}