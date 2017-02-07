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

			// Generate 20x20 chunks
			for (int i = -10; i <= 10; i++)
			{
				for (int j = -10; j <= 10; j++)
				{
					CreateChunk (new ChunkCoord (i, j));
				}
			}

			// Set center to solid ground
			const int radius = 5;
			for (int x = -radius; x <= radius; x++)
			{
				for (int y = -radius; y <= radius; y++)
				{
					Cell c;
					if (TryGetCell (x, y, out c))
					{
						ColonyCell cc = (c as ColonyCell);
						cc.Biome = BiomeManager.Instance.Biomes [2];
					}
				}
			}
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
			int chunkX = (x - Util.mod(x, Chunk.Size)) / Chunk.Size;
			int chunkY = (y - Util.mod(y,Chunk.Size)) / Chunk.Size;

			ChunkCoord coord = new ChunkCoord(chunkX, chunkY);

            Chunk chunk;
            if (_chunks.TryGetValue(coord, out chunk))
            {
				int xIndex = Util.mod(x, Chunk.Size);
				int yIndex = Util.mod(y, Chunk.Size);
				c = chunk.GetCell(xIndex, yIndex);
                return true;
            }
            c = null;
            return false;
        }

        private Chunk CreateChunk(ChunkCoord chunkCoord)
        {
			var noise = Noise.GetNoiseGrid (chunkCoord);

            Chunk chunk = new Chunk(chunkCoord);
            for (int i = 0; i < Chunk.Size; i++)
            {
                for (int j = 0; j < Chunk.Size; j++)
                {
                    var chunkPos = chunkCoord.ToAxial();
                    var cellPos = new AxialCoord(chunkPos.X + i, chunkPos.Y + j);
					var biome = GetBiome (noise[i,j]);
					var cell = CreateCell(cellPos, biome);
                    chunk.SetCell(i, j, cell);
                }
            }
            _chunks.Add(chunkCoord, chunk);
            return chunk;
        }

		private Cell CreateCell(AxialCoord coords, Biome biome)
        {
			GameObject o = Instantiate(CellPrefab) as GameObject;
			o.transform.parent = transform;
            o.transform.localPosition = coords.ToPosition();
            var cell = o.GetComponent<Cell>();
            cell.Coord = coords;
			cell.Init (biome);
            return cell;
        }

		private Biome GetBiome(float val)
		{
			var lowestBiome = BiomeManager.Instance.Biomes [0];
			foreach (Biome b in BiomeManager.Instance.Biomes)
			{
				if (b.Value < lowestBiome.Value && b.Value >= val)
				{
					lowestBiome = b;
				}
			}
			return lowestBiome;
		}
    }
}