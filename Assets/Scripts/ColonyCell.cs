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

        // Randomly assign attributes TODO: do correctly
        void Start()
        {
            Biome = Util.PickRandomFrom(BiomeManager.Instance.Biomes);
            GetComponent<SpriteRenderer>().color = Biome.Color;
        }

        public Biome Biome
        {
            get;
            set;
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
                float multiplier = 1.0f;
                foreach (Feature f in Features)
                {
                    multiplier *= f.BuildTimeMultiplier;
                }
                return multiplier;
            }
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
    }
}
