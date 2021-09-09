using UnityEngine;

namespace GameBoard.Tile
{
    public class BadTileController : TileBase
    {
        public int myNumber;

        public override bool LightOn() => false;
        public override bool LightOff() => false;

        public override bool IsValid()
        {
            int selectedNeighbours = 0;
            foreach (var tile in neighbours) 
                if (tile.IsSelected)
                    selectedNeighbours++;
            if (selectedNeighbours == myNumber)
                return true;
            MyTileRenderer.WrongAnim();
            return selectedNeighbours == myNumber;
        }
    }
}