namespace SpencerHaney
{
    using UnityEngine;

    public class Cell : MonoBehaviour
    {
        private AxialCoord _coord;

        public AxialCoord Coord
        {
            set { _coord = value; }
            get { return _coord; }
        }
    }
}