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

		[SerializeField]
		private float _value;

		public float Value
		{
			get { return _value; }
			private set { _value = value; }
		}

		public Biome(string name, Color color, float value)
        {
            Name = name;
            Color = color;
			Value = value;
        }

		public override string ToString ()
		{
			return Name;
		}
    }
}