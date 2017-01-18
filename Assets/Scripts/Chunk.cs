namespace SpencerHaney
{
    public class Chunk
    {
        public const int Size = 10;
        private Cell[,] _grid;
        private ChunkCoord _coord;

        public ChunkCoord Coord
        {
            get { return _coord; }
        }

        public Chunk(ChunkCoord coord)
        {
            _coord = coord;
            _grid = new Cell[Size, Size];
        }

        /// <summary>
        /// Set the cell at the x and y values <em>relative to the chunk's coordinates</em>
        /// </summary>
        /// <param name="x">The x position relative to the chunk's coordinates</param>
        /// <param name="y">The y position relative to the chunk's coordinates</param>
        /// <param name="c">The cell to set</param>
        public void SetCell(int x, int y, Cell c)
        {
            _grid[x, y] = c;
        }

        /// <summary>
        /// Get's the cell using the x and y values <em>relative to the chunk's coordinate</em>
        /// </summary>
        /// <param name="x">The x position relative to the chunk's coordinates</param>
        /// <param name="y">The y position relative to the chunk's coordinates</param>
        /// <returns>The Cell at the given coord</returns>
        public Cell GetCell(int x, int y)
        {
            return _grid[x, y];
        }
    }
}