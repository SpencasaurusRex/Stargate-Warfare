namespace SpencerHaney
{
    public class Chunk
    {
        public const int Size = 10;
        private Cell[,] grid;

        public Chunk()
        {
            grid = new Cell[Size, Size];
        }
    }
}