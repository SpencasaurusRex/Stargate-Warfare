namespace SpencerHaney
{
    using UnityEngine;

    [System.Serializable]
    public class Biome
    {
        [SerializeField]
        private string _name;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        [SerializeField]
        private Color _color;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Biome(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}