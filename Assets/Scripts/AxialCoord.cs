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
            return new Vector3(X + Y / 2f, Y * YScale, 0);
        }
    }
}
