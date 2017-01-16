namespace SpencerHaney
{

    public class Planet
    {
        private HexGrid _grid;

        public HexGrid Grid
        {
            get { return _grid; }
        }

        public Planet()
        {
            _grid = new HexGrid();
        }
    }
}