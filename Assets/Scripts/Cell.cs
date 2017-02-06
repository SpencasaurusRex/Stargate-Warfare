namespace SpencerHaney
{
    using UnityEngine;

    public abstract class Cell : MonoBehaviour
    {
        private AxialCoord _coord;

        public AxialCoord Coord
        {
            set { _coord = value; }
            get { return _coord; }
        }

		// TODO: abstract away biome, allow more general types
		// ex: when initing a space hex, can give SpaceBiome
		public abstract void Init(Biome b);
    }
}