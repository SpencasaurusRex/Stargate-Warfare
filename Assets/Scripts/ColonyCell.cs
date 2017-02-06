namespace SpencerHaney
{
    using UnityEngine;
    using System.Collections.Generic;

    /// <summary>
    /// The type of cell that is used in the colony manager view.
    /// Not necessarily part of a colony
    /// </summary>
    public class ColonyCell : Cell
    {
        private List<Feature> _features;
		private Biome _biome;

		#region Unity Methods
        void Start()
        {
            
        }
		#endregion	

		#region Properties
        public Biome Biome
        {
            get
			{ 
				return _biome;
			}

            set
			{ 
				_biome = value;
				GetComponent<SpriteRenderer> ().color = _biome.Color;
			}
        }

		public Feature[] Features
        {
            get { return _features.ToArray(); }
        }
        
		public bool CanBeBuiltOn
        {
            get
            {
                bool can = true;
                foreach (Feature f in Features)
                {
                    if (!f.CanBeBuiltOn)
                    {
                        can = false;
                    }
                }
                return can;
            }
        }

        public float BuildTimeMultiplier
        {
            get
            {
                var multiplier = 1.0f;
                foreach (Feature f in Features)
                {
                    multiplier *= f.BuildTimeMultiplier;
                }
                return multiplier;
            }
        }
		#endregion
		
		#region Methods
		public override void Init(Biome b)
		{
			Biome = b;
		}

        public void AddFeature(Feature f)
        {
            _features.Add(f);
        }

        public void RemoveFeature(Feature f)
        {
            if (_features.Contains(f))
            {
                _features.Remove(f);
            }
        }
		#endregion
    }
}
