using UnityEngine;

namespace GameBoard.Tile
{
    public class BadTileController : TileBase
    {
        private int _myNumber;
        
        public override bool LightOn()
        {
            return false;
        }

        public override void LightOff()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsValid()
        {
            int selectedNeighbours = 0;
            foreach (var tile in neighbours) 
                if (tile.IsSelected)
                    selectedNeighbours++;
            if (selectedNeighbours == _myNumber)
                return true;
            MyTileRenderer.WrongAnim();
            return selectedNeighbours == _myNumber;
        }
    }
}