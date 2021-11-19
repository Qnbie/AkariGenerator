using UnityEngine;

namespace Game.GameBoard.Tile
{
    [RequireComponent(typeof(TileRenderer), typeof(Collider))]
    public class GoodTileController : TileBase
    {
        public event IsSelectedDelegate OnSelect;

        private bool IsLighted => lightCounter > 0;

        [SerializeField]private int lightCounter;
        
        public override bool LightOn()
        {
            lightCounter++;
            MyTileRenderer.TurnOn();
            return true;
        }

        public override bool LightOff()
        {
            lightCounter--;
            if (lightCounter > 0) return true;
            lightCounter = 0;
            MyTileRenderer.TurnOff();
            return true;
        }

        public override bool IsValid()
        {
            if (IsLighted && isSelected)
            {
                Debug.Log(name + " is wrong");
                MyTileRenderer.NotAllowed();
            }

            if (!(IsLighted ^ isSelected)) return false;
            MyTileRenderer.Allowed();
            return true;
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