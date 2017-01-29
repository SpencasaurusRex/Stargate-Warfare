namespace SpencerHaney
{
    using UnityEngine;
    using System.Collections.Generic;

    public class HexGrid : MonoBehaviour
    {
        public static GameObject CellPrefab;

        private Dictionary<ChunkCoord, Chunk> _chunks;

        void Start()
        {
            _chunks = new Dictionary<ChunkCoord, Chunk>();
			CreateChunk (new ChunkCoord(0,0)); // Center

			CreateChunk (new ChunkCoord(0,1)); // N
			CreateChunk (new ChunkCoord(1,1)); // NE
			CreateChunk (new ChunkCoord(1,0)); // E
			CreateChunk (new ChunkCoord(1,-1)); // SE
			CreateChunk (new ChunkCoord(0,-1)); // S
			CreateChunk (new ChunkCoord(-1,-1)); // SW
			CreateChunk (new ChunkCoord(-1,0)); // W
			CreateChunk (new ChunkCoord(-1,1)); // NW
		}

        /// <summary>
        /// Try to get the cell at the given axial coordinates.
        /// </summary>
        /// <param name="coord">The x axial coords</param>
        /// <param name="c">If a chunk exists at the position, then is assigned the cell, otherwise null</param>
        /// <returns>Whether or not a chunk exists at the given position</returns>
        public bool TryGetCell(AxialCoord coord, out Cell c)
        {
            return TryGetCell(coord.X, coord.Y, out c);
        }

        /// <summary>
        /// Try to get the cell at the given axial coordinates.
        /// </summary>
        /// <param name="x">The x axial coord</param>
        /// <param name="y">The y axial coord</param>
        /// <param name="c">If a chunk exists at the position, then is assigned the cell, otherwise null</param>
        /// <returns>Whether or not a chunk exists at the given position</returns>
        public bool TryGetCell(int x, int y, out Cell c)
        {
            ChunkCoord coord = new ChunkCoord(x / Chunk.Size, y / Chunk.Size);

            Chunk chunk;
            if (_chunks.TryGetValue(coord, out chunk))
            {
                int xIndex = x % Chunk.Size;
                int yIndex = y % Chunk.Size;
                c = chunk.GetCell(xIndex, yIndex);
                return true;
            }
            c = null;
            return false;
        }

        private Chunk CreateChunk(ChunkCoord chunkCoord)
        {
            Chunk chunk = new Chunk(chunkCoord);
            for (int i = 0; i < Chunk.Size; i++)
            {
                for (int j = 0; j < Chunk.Size; j++)
                {
                    AxialCoord chunkPos = chunkCoord.ToAxial();
                    AxialCoord cellPos = new AxialCoord(chunkPos.X + i, chunkPos.Y + j);
                    Cell c = CreateCell(cellPos);
                    chunk.SetCell(i, j, c);
                }
            }
            _chunks.Add(chunkCoord, chunk);
            return chunk;
        }

        private Cell CreateCell(AxialCoord coords)
        {
			GameObject o = Instantiate(CellPrefab) as GameObject;
			o.transform.parent = transform;
            o.transform.localPosition = coords.ToPosition();
            Cell cell = o.GetComponent<Cell>();
            cell.Coord = coords;
            return cell;
        }
    }
}