namespace SpencerHaney
{
    using System.Collections.Generic;

    public class HexGrid
    {
        private Dictionary<ChunkCoord, Chunk> _chunks;

        public HexGrid()
        {
            _chunks = new Dictionary<ChunkCoord, Chunk>();
        }

        public Cell GetCell(AxialCoord coord)
        {
            return GetCell(coord.X, coord.Y);
        }

        public Cell GetCell(int x, int y)
        {
            ChunkCoord c = new ChunkCoord(x / Chunk.Size, y / Chunk.Size);

            return null; // TODO stub
        }
    }
}