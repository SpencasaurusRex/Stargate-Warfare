namespace SpencerHaney
{
    public class ChunkCoord : IntVector2
    {
        public ChunkCoord(int x, int y) : base(x, y)
        {
        }

        public AxialCoord ToAxial()
        {
            return new AxialCoord(x * Chunk.Size, y * Chunk.Size);
        }
    }
}