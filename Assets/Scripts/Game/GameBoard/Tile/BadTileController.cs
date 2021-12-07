using System.Linq;

namespace Game.GameBoard.Tile
{
    public class BadTileController : TileBase
    {
        private int _myNumber;

        public int MyNumber
        {
            set
            {
                if(value < 5) 
                    MyTileRenderer.SetNumber(value);
                _myNumber = value;
            }
        }

        public override bool LightOn() => false;
        public override bool LightOff() => false;

        public override bool IsValid()
        {
            if (_myNumber >= 5) return true;
            var selectedNeighbours = neighbours.Count(tile => tile.lampPlaced);
            if (selectedNeighbours == _myNumber)
            {
                MyTileRenderer.Allowed();
                return true;
            }
            if(selectedNeighbours > _myNumber)
                MyTileRenderer.NotAllowed();
            return false;
        }
    }
}