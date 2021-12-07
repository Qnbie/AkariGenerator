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
            if (IsLighted && lampPlaced)
            {
                Debug.Log(name + " is wrong");
                MyTileRenderer.NotAllowed();
            }

            if (!(IsLighted ^ lampPlaced)) return false;
            MyTileRenderer.Allowed();
            return true;
        }

        private void OnMouseDown()
        {
            lampPlaced = !lampPlaced;
            if(lampPlaced) MyTileRenderer.AddSelection();
            else MyTileRenderer.RemoveSelection();
            OnSelect?.Invoke(this);
        }
    }
    public delegate void IsSelectedDelegate(GoodTileController selectedTile);
}