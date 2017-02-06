namespace SpencerHaney
{
    using UnityEngine;

    public class AxialCoord : IntVector2
    {
        public readonly static float YScale = Mathf.Cos(Mathf.PI / 6);

        public AxialCoord(int x, int y) : base(x, y)
        {

        }

        public Vector3 ToPosition()
        {
			return ToPosition (X, Y);
        }

		public static Vector3 ToPosition(int X, int Y)
		{
			var absY = Mathf.Abs(Y);
			var x = X + absY / 2f - absY / 2;
			var y = Y * YScale;
			return new Vector3(x, y, 0);
		}
    }
}
