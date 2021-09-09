using UnityEngine;

namespace GameBoard.Tile
{
    public class BadTileController : TileBase
    {
        public override bool LightOn()
        {
            return false;
        }

        public override void LightOff()
        {
            throw new System.NotImplementedException();
        }
    }
}