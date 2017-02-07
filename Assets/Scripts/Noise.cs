namespace SpencerHaney
{
	using UnityEngine;
	public class Noise
	{
		public static float[,] GetNoiseGrid(ChunkCoord chunkCoord)
		{
			const float scale = 8;

			var map = new float[Chunk.Size,Chunk.Size];
			var axialPos = chunkCoord.ToAxial ();

			for (int x = 0; x < Chunk.Size; x++)
			{
				for (int y = 0; y < Chunk.Size; y++)
				{
					// Figure out where we are in actual space
					var actualPos = AxialCoord.ToPosition(axialPos.X + x, axialPos.Y + y) / scale;

					// Since Perlin noise mirrors about x and y axis, add large offset 
					// TODO: replace with simplex noise to avoid this problem?
					actualPos += new Vector3(10000, 10000, 0);
					// Assign value using basic Perlin noise TODO: use fractal
					map [x, y] = Mathf.PerlinNoise (actualPos.x, actualPos.y);
				}
			}

			return map;
		}
	}
}